namespace CoreAPP.Services
{
    using CoreApp.Models;
    using CoreAPP.Contracts;
    using Forum_App.Data;
    using Forum_App.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class PostService : IPostService
    {
        private readonly ForumAppDbContext forumAppDbContext;
        public PostService(ForumAppDbContext forumAppDbContext)
        {
            this.forumAppDbContext = forumAppDbContext;
        }

        public async Task<List<PostViewModel>> GetAllAsync()
        {
            List<PostViewModel> posts = await forumAppDbContext.Posts
                  .Where(p => !p.IsDeleted)
                  .Select(p => new PostViewModel()
                  {
                      Id = p.Id,
                      Title = p.Title,
                      Content = p.Content

                  }).ToListAsync();
            return posts;
        }
        public async Task AddPostAsync(PostFormModel postFormModel)
        {
            Post postToAdd = new Post()
            {
                Title = postFormModel.Title,
                Content = postFormModel.Content
            };
            await forumAppDbContext.Posts.AddAsync(postToAdd);
            await forumAppDbContext.SaveChangesAsync();
        }
        public async Task<PostFormModel> FindByIdAsync(int id)
        {
            Post post = await forumAppDbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if (post != null)
            {
                return new PostFormModel()
                {
                    Title = post.Title,
                    Content = post.Content
                };
            }
            else
            {
                throw new InvalidOperationException("Invalid post Id");
            }
        }

        public async Task EditPostAsync(int id, PostFormModel postFormModel)
        {
            Post post = await forumAppDbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (post != null)
            {
                post.Title = postFormModel.Title;
                post.Content = postFormModel.Content;
                await forumAppDbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Invalid post Id");
            }
        }
        public async Task DeletePostAsync(int id)
        {
            Post post = await forumAppDbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            post.IsDeleted = true;
            await forumAppDbContext.SaveChangesAsync();
        }
    }
}
