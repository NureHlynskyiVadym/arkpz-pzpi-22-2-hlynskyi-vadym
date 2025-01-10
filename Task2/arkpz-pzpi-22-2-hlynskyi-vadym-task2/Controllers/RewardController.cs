using LevelUp.Interfaces;
using LevelUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LevelUp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RewardsController : ControllerBase
    {
        private readonly IRewardRepository _rewardRepository;

        public RewardsController(IRewardRepository rewardRepository)
        {
            _rewardRepository = rewardRepository;
        }

        [HttpGet]
        public IActionResult GetRewards()
        {
            var rewards = _rewardRepository.GetRewards();
            return Ok(new { success = true, data = rewards });
        }

        [HttpGet("{id}")]
        public IActionResult GetRewardById(int id)
        {
            var reward = _rewardRepository.GetRewardById(id);
            if (reward == null)
                return NotFound(new { success = false, message = $"Reward with ID {id} not found." });

            return Ok(new { success = true, data = reward });
        }

        [HttpPost]
        public IActionResult CreateReward([FromBody] Reward reward)
        {
            if (reward == null)
                return BadRequest(new { success = false, message = "Reward cannot be null" });

            if (!_rewardRepository.AddReward(reward))
                return StatusCode(500, new { success = false, message = "Error creating the reward" });

            return CreatedAtAction(nameof(GetRewardById), new { id = reward.RewardId }, new { success = true, data = reward });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReward(int id, [FromBody] Reward reward)
        {
            if (id != reward.RewardId)
                return BadRequest(new { success = false, message = "ID mismatch" });

            var existingReward = _rewardRepository.GetRewardById(id);
            if (existingReward == null)
                return NotFound(new { success = false, message = $"Reward with ID {id} not found." });

            if (!_rewardRepository.UpdateReward(reward))
                return StatusCode(500, new { success = false, message = "Error updating the reward" });

            return Ok(new { success = true, data = reward });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReward(int id)
        {
            if (!_rewardRepository.DeleteReward(id))
                return NotFound(new { success = false, message = $"Reward with ID {id} not found." });

            return Ok(new { success = true });
        }

        [HttpPost("{rewardId}/claim")]
        public IActionResult ClaimReward(int rewardId, [FromBody] int userId)
        {
            var reward = _rewardRepository.GetRewardById(rewardId);
            if (reward == null)
                return NotFound(new { success = false, message = $"Reward with ID {rewardId} not found." });

            var isClaimed = _rewardRepository.ClaimReward(userId, rewardId);
            if (!isClaimed)
                return BadRequest(new { success = false, message = "Reward could not be claimed, either it was already claimed or an error occurred." });

            return Ok(new { success = true, message = "Reward successfully claimed!" });
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetRewardsByUserId(int userId)
        {
            var rewards = _rewardRepository.GetRewardsByUserId(userId);
            if (rewards == null || !rewards.Any())
                return NotFound(new { success = false, message = $"No rewards found for user with ID {userId}." });

            return Ok(new { success = true, data = rewards });
        }


    }
}
