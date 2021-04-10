using System.Linq;
using AdminApprovalBack.Models;
using AdminApprovalBack.Services.SystemManage;
using Data.Entity.SystemManage;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace AdminApprovalBack.Controllers.SystemManage
{
    [Area("SystemManage")]
    public class UserOrganizeController : ControllerBase
    {
        private readonly RepoService<UserOrganizeEntity> repoService;
        private readonly UserService userService;
        private readonly RepoService<OrganizeEntity> organizeService;

        public UserOrganizeController(RepoService<UserOrganizeEntity> repoService,
            UserService userService,
            RepoService<OrganizeEntity> organizeService)
        {
            this.repoService = repoService;
            this.userService = userService;
            this.organizeService = organizeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Success(repoService.IQueryable().ToList().Select(it => new UserOrganizeModel
            {
                Id = it.Id,
                UserId = it.User.Id,
                OrganizeId = it.Organize.Id,
                DutyLevel = it.DutyLevel
            }));
        }

        [HttpPost]
        public IActionResult Update([FromBody] UserOrganizeModel userOrganizeModel)
        {
            UserOrganizeEntity entity = new()
            {
                User = userService.FindOne(userOrganizeModel.UserId),
                Organize = organizeService.FindOne(userOrganizeModel.OrganizeId),
                DutyLevel = userOrganizeModel.DutyLevel
            };

            repoService.Update(entity);
            return Success();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            repoService.Delete(id);
            return Success();
        }
    }
}