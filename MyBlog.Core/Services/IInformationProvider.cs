using System.Threading.Tasks;

namespace MyBlog.Core
{
    public interface IInformationProvider
    {
        Task<GitHubCommitInfo?> GetCommitInfoAsync(string path);
        Task<GitHubSearchResult?> GetEntriesAsync(int from, int count);
        Task<GitHubSearchResult?> GetLastEntriesAsync();
        Task<string?> GetMarkDownContentInHtmlFormat(string url, bool excerpt);
        Task<GitHubUserInfo?> GetUserInfoAsync();
        Task<GitHubSearchResult?> SearchInFileContentAsync(string query, int from = 0, int count = int.MaxValue);
    }
}