using Core.CrossCuttingConcerns.Rules;
using Core.Entities;
using Core.Exceptions.Types;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;

namespace Business.Rules;

public class UserBusinessRules : BaseBusinessRules
{

    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is not null) throw new BusinessException("User mail already exists");
    }

    public async Task UserEmailShouldBeExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is null) throw new BusinessException("Email or Password don't match");
    }

    public Task UserShouldBeExists(User? user)
    {
        if (user is null) throw new BusinessException("Email or Password don't match");
        return Task.CompletedTask;
    }

    public async Task UserPasswordShouldBeMatch(Guid id, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Email or Password don't match");
    }
}