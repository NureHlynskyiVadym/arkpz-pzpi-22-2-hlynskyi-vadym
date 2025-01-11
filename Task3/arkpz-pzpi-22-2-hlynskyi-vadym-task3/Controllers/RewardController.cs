using LevelUp.Interfaces;
using LevelUp.Models;
using LevelUp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardsController : ControllerBase
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly IUserRepository _userRepository;

        public RewardsController(IRewardRepository rewardRepository, IUserRepository userRepository)
        {
            _rewardRepository = rewardRepository;
            _userRepository = userRepository;
        }

        [HttpPost("{rewardId}/claim")]
        public IActionResult ClaimReward(int rewardId, [FromBody] int userId)
        {
            var reward = _rewardRepository.GetRewardById(rewardId);
            if (reward == null)
                return NotFound(new { success = false, message = $"Reward with ID {rewardId} not found." });

            var user = _userRepository.GetUserById(userId);
            if (user == null)
                return NotFound(new { success = false, message = $"User with ID {userId} not found." });

            if (user.Points < reward.Price)
                return BadRequest(new { success = false, message = "Not enough points to claim this reward." });

            user.Points -= reward.Price;
            if (!_userRepository.UpdateUser(user))
                return StatusCode(500, new { success = false, message = "Error updating user points." });

            var isClaimed = _rewardRepository.ClaimReward(userId, rewardId);
            if (!isClaimed)
                return StatusCode(500, new { success = false, message = "Reward could not be claimed, either it was already claimed or an error occurred." });

            return Ok(new { success = true, message = "Reward successfully claimed!", data = new { user.Points, reward.Price } });
        }
    }
}
