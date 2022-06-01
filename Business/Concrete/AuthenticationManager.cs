using Business.Abstract;
using Core.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Rules;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT.Abstract;
using Core.Utilities.Security.JWT.Models;
using Entities.Dtos;
using Results.State;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IUserService UserService { get; }
        private ITokenHelper TokenHelper { get; }
        public AuthenticationManager(IUserService userService, ITokenHelper tokenHelper)
        {
            UserService = userService;
            TokenHelper = tokenHelper;
        }

        public IDataResult<AuthenticatedDto> Login(UserForLoginDto userForLoginDto)
        {
            var checkUser = CheckUser(userForLoginDto.Email);
            if (checkUser.Status == false)
            {
                return new ErrorDataResult<AuthenticatedDto>(checkUser.Message);
            }
            var createAccessToken = this.CreateAccessToken(checkUser.Data);
            var authenticatedDto = new AuthenticatedDto()
            {
                Id = checkUser.Data.Id,
                Expiration = createAccessToken.Data.Expiration,
                Token = createAccessToken.Data.Token,
                UserEmail = checkUser.Data.Email,
                UserFirstName = checkUser.Data.FirstName,
                UserLastName = checkUser.Data.LastName
            };

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,checkUser.Data.PasswordHash,checkUser.Data.PasswordSalt))
            {
                return new ErrorDataResult<AuthenticatedDto>(authenticatedDto,Messages.ErrorPasswordOperation);
            }

            return new SuccessDataResult<AuthenticatedDto>(authenticatedDto,Messages.SuccessLoginOperation);
        }

        public IDataResult<AuthenticatedDto> Register(UserForRegisterDto userForRegisterDto)
        {
            var checkUser = CheckUser(userForRegisterDto.Email);
            if (checkUser.Status == true)
            {
                return new ErrorDataResult<AuthenticatedDto>(checkUser.Message);
            }

            var hashingHelper = HashingHelper.CreatePasswordHash(userForRegisterDto.Password);

            User newUser = new User()
            {
                Id=0,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                IsApproved = true,
                PasswordHash = hashingHelper.Hash,
                PasswordSalt = hashingHelper.Salt
            };

            UserService.Add(newUser);

            var createAccessToken = this.CreateAccessToken(newUser);

            var authenticatedDto = new AuthenticatedDto()
            {
                Expiration = createAccessToken.Data.Expiration,
                Token = createAccessToken.Data.Token,
                UserEmail = newUser.Email,
                UserFirstName = newUser.FirstName,
                UserLastName = newUser.LastName
            };

            return new SuccessDataResult<AuthenticatedDto>(authenticatedDto,Messages.SuccessRegisterOperation);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationCliams = new List<OperationClaim>();

            var userOperationClaimsDto = UserService.GetClaims(user);     
            
            foreach (var userOperationClaimDto in userOperationClaimsDto.ListData)
            {
                operationCliams.Add(
                        new OperationClaim() 
                        {
                            Id = userOperationClaimDto.OperationClaimId,
                            Name = userOperationClaimDto.OperationClaimName,
                            IsApproved = userOperationClaimDto.OperationClaimIsApproved 
                        }
                    );
            }

            var accessToken = TokenHelper.CreateToken(user, operationCliams);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.CreatedAccessToken);
        }

        private IDataResult<User> CheckUser(string email)
        {
            var result = UserService.GetByUserEmail(email);
            if (result.SingleData == null)
            {
                return new ErrorDataResult<User>(result.SingleData,Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result.SingleData,Messages.UserFound);
        }
    }
}
