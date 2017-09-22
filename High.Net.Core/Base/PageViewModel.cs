using System;
using EPiServer.Core;

namespace High.Net.Core
{
    public class PageViewModel<T> : IPageViewModel<T> where T : BasePageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        public T CurrentPage { get; private set; }
    }

    public static class PageViewModel
    {
        /// <summary>
        /// Returns a PageViewModel of type <typeparam name="T"/>.
        /// </summary>
        /// <remarks>
        /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
        /// </remarks>
        public static PageViewModel<T> Create<T>(T page) where T : BasePageData
        {
            return new PageViewModel<T>(page);
        }
    }
}
