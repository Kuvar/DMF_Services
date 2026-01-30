using Asp.Versioning;
using DMF_Services.DTOs.UserDetails;
using DMF_Services.Helpers;
using DMF_Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DMF_Services.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/user-details")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailService _service;

        public UserDetailsController(IUserDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDetailDto>>>> GetAll()
        {
            var data = await _service.GetAllAsync();

            return Ok(new ApiResponse<IEnumerable<UserDetailDto>>
            {
                Success = true,
                Message = "User details fetched successfully",
                Data = data
            });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<UserDetailDto>>> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound(new ApiResponse<UserDetailDto>
                {
                    Success = false,
                    Message = "User detail not found"
                });
            }

            return Ok(new ApiResponse<UserDetailDto>
            {
                Success = true,
                Message = "User detail fetched successfully",
                Data = data
            });
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<int>>> Create(CreateUserDetailDto dto)
        {
            var id = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(Get), new { id },
                new ApiResponse<int>
                {
                    Success = true,
                    Message = "User detail created successfully",
                    Data = id
                });
        }
    }
}
