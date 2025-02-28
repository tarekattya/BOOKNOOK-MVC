using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MVCP_BookStore.Models;

namespace BookStore.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<DefaultUser> _userManager;
        private readonly ILogger<ConfirmEmailModel> _logger;

        public ConfirmEmailModel(UserManager<DefaultUser> userManager, ILogger<ConfirmEmailModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            _logger.LogInformation($"ConfirmEmail: Received userId = {userId}, encodedCode = {code}");

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                _logger.LogError("ConfirmEmail: userId or code is missing.");
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogError($"ConfirmEmail: Unable to load user with ID '{userId}'.");
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            try
            {
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                _logger.LogInformation("ConfirmEmail: Decoded email confirmation token.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"ConfirmEmail: Failed to decode email confirmation code. Error: {ex.Message}");
                return BadRequest("Invalid email confirmation code format.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                _logger.LogInformation($"ConfirmEmail: Email confirmed for user {user.Email}.");
                StatusMessage = "Thank you for confirming your email.";
            }
            else
            {
                _logger.LogError($"ConfirmEmail: Error confirming email for user {user.Email}. Errors: {string.Join(", ", result.Errors)}");
                StatusMessage = "Error confirming your email.";
            }

            return Page();
        }
    }
}
