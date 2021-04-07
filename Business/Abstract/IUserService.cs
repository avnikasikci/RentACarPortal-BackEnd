using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        IDataResult<User> GetById(int id);

        IDataResult<List<User>> GetAll();

        IResult AddResult(User user);

        IResult Update(User user);

        IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate);

        IResult Delete(User user);

        IDataResult<List<OperationClaim>> GetClaimsDataResult(User user);

        IDataResult<User> GetByMailDataResult(string userMail);

        IDataResult<UserDetailDto> GetUserDetailByMail(string userMail);

    }
}
