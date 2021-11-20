using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserManager : EfEntityRepositoryBase<User, HobbyContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (HobbyContext context = new HobbyContext())
            {
                var result = from operationClaims in context.OperationClaims
                             join useroperationClaims in context.UserOperationClaims
                       on operationClaims.Id equals useroperationClaims.OperationClaimId
                             join users in context.Users
                             on useroperationClaims.UserId equals users.Id
                             select new OperationClaim
                             {
                                 Id = operationClaims.Id,
                                 Name = operationClaims.Name
                             };
                return result.ToList();
                            
            }
           

            
        }
    }
}
