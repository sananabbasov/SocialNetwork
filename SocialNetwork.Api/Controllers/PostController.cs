using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SocialNetwork.Business.Abstract;
using System.IdentityModel.Tokens.Jwt;
using static SocialNetwork.Entities.DTOs.PostDTO;

namespace SocialNetwork.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IPostLikeService _postLikeService;
        public PostController(IPostService postService, IPostLikeService postLikeService)
        {
            _postService = postService;
            _postLikeService = postLikeService;
        }

        [Authorize]
        [HttpPost("publishpost")]
        public IActionResult AddPost(PostCreateDTO post)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            _postService.CreatePost(post, Guid.Parse(id));

            return Ok();
        }

        [Authorize]
        [HttpPost("likepost/{postId}")]
        public IActionResult LikePost(int postId)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
            var result = _postLikeService.LikePost(Guid.Parse(id),postId);
            return Ok(new { success = result.Success, message = result.Message });
        }

    }
}
