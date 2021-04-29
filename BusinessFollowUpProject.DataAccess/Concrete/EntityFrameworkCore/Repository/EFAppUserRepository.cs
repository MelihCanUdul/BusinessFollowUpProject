using BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using BusinessFollowUpProject.DataAccess.Interfaces;
using BusinessFollowUpProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessFollowUpProject.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EFAppUserRepository :IAppUser
    {
        public List<AppUser> GetNonAdmins()
        {
            //Rolü kullanıcı olanların isimleri admin sayfasında listelenmek için yapılmış sorgu. Bu sayede 3 adet tablo birleştirilmiştir.
          using var context = new BusinessFollowUpProjectContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles,twotableresult=> twotableresult.userRole.RoleId,role=>role.Id,(resultTable,resultRole)=>new
                {
                    user=resultTable.user,
                   userroles=resultTable.userRole,
                   roles=resultRole
                }).Where(I=>I.roles.Name=="Member").Select(I=>new AppUser()
                {
                    Id=I.user.Id,
                    Name= I.user.Name,
                    SurName= I.user.SurName,
                    Picture= I.user.Picture,
                    Email= I.user.Email,
                    UserName= I.user.UserName

                }).ToList();
        }

        public List<AppUser> GetNonAdmins(out int totalpage,string searchword,int activepage=1)
        {
            //Rolü kullanıcı olanların isimleri admin sayfasında listelenmek için yapılmış sorgu. Bu sayede 3 adet tablo birleştirilmiştir.
            using var context = new BusinessFollowUpProjectContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole
                }).Join(context.Roles, twotableresult => twotableresult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userroles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
                {
                    Id = I.user.Id,
                    Name = I.user.Name,
                    SurName = I.user.SurName,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName

                });
            totalpage = (int)Math.Ceiling((double)result.Count()/3);
            if(!string.IsNullOrWhiteSpace(searchword))
            {
                result=result.Where(I => I.Name.ToLower().Contains(searchword.ToLower()) || I.SurName.ToLower().Contains(searchword.ToLower()));
                totalpage = (int)Math.Ceiling((double)result.Count() / 3);
            }
            result = result.Skip((activepage - 1) * 3).Take(3);
            return result.ToList();
        }
        public List<DualHelper> MostTaskCompleted()
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Include(I => I.AppUser).Where(I => I.Status).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                TaskCount = I.Count()
            }).ToList();

        
        }
        public List<DualHelper> MostWorkTaskCompleted()
        {
            using var context = new BusinessFollowUpProjectContext();
            return context.Tasks.Include(I => I.AppUser).Where(I => !I.Status && I.AppUserId !=null).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                TaskCount = I.Count()
            }).ToList();


        }
    }
}
