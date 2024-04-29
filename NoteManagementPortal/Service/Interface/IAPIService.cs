using NoteManagementPortal.Models;

namespace NoteManagementPortal.Service.Interface
{
    public interface IAPIService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<GetAllNotesByUserIdResponse> GetAllNotesByUserId(int UserId, string AccessToken);
        Task<bool> DeleteNote(int NoteId, int UserId, string AccessToken);
        Task<bool> RegisterUser(RegisterUesrRequest registerUesrRequest);

        Task<UesrProfileResponse> GetUserProfile(int UserId, string AccessToken);


    }
}
