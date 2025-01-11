using LevelUp.Models;
using System.Collections.Generic;

namespace LevelUp.Interfaces
{
    public interface IRewardRepository
    {
        ICollection<Reward> GetRewards();
        Reward GetRewardById(int id);
        ICollection<Reward> GetRewardsByUserId(int userId);

        bool AddReward(Reward reward);
        bool UpdateReward(Reward reward);
        bool DeleteReward(int id);
        bool ClaimReward(int userId, int rewardId);

        bool Save();
    }
}
