using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public UserDetailDto GetUserDetail(string userMail)
        {
            using (var context = new RentACarContext())
            {
                //var AllUsers = context.Users.ToList().Where(x=>x.Email == userMail).ToList();
                //var AllCustomer = context.Customers.ToList();
                ////context.Customers.Add(new Customer { CompanyName = "Avni", UserId = AllUsers.FirstOrDefault().Id });
                ////context.SaveChanges();
                //var AllCustomer2 = context.Customers.ToList();
                var result =
                    (from u in context.Users
                     join c in context.Customers
                         on u.Id equals c.UserId
                     join userOperationClaim in context.UserOperationClaims
                    on u.Id equals userOperationClaim.UserId
                     where u.Email == userMail
                     select new UserDetailDto
                     {
                         Id = u.Id,
                         CustomerId = c.Id,
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         Email = u.Email,
                         CompanyName = c.CompanyName,
                         userOperationClaimId= userOperationClaim.Id,
                         OperationClaimId= userOperationClaim.OperationClaimId,
                         //OperationClaimName=context.OperationClaims.Where(x=>x.Id== userOperationClaim.OperationClaimId).FirstOrDefault()?.Name
                     }).ToList();
                result.ForEach(x => x.OperationClaimName = context.OperationClaims.Where(y => y.Id == x.userOperationClaimId).FirstOrDefault()?.Name);
                result.ForEach(x => x.RoleName =x.OperationClaimName);
                return result.FirstOrDefault();
                //var _ReturnResult = result.Where(x => x.Email.Contains(userMail)).FirstOrDefault();                
                //return _ReturnResult;
            }
        }
    }
}