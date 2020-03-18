using BookLibrary.Repositories.Services;
using System.Linq;
using Xunit;


namespace BookLibrary.Repositories.Test.Services.AuthorRepository_Tests
{
    public class Test_that
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(20)]
        public void for_every_test_method_the_database_content_is_same(int authorsToAddCount)
        {
            // Arrange
            var sut = new AuthorRepository(
                DatabaseContextProvider.GetDatabaseContextMock());

            // Act
            AddAuthorsToDatabase(sut, authorsToAddCount);
            var task = sut.GetAuthorsAsync();
            task.Wait();
            var authorList = task.Result.ToList();

            // Assert
            Assert.Equal(authorsToAddCount + 4, authorList.Count); // because after initialization the database contains 4 authors
        }


        #region PRIVATE METHODS

        private void AddAuthorsToDatabase(AuthorRepository repo, int authorsToAddCount)
        {
            for (var i = 0; i < authorsToAddCount; i++)
            {
                var task = repo.AddAuthorAsync($"Jack the {i + 1}", "Sparrow");
                task.Wait();
            }
            repo.SaveChangesAsync().Wait();
        }

        #endregion

    }
}
