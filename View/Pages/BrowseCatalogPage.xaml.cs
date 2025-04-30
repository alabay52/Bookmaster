using Bookmaster.AppData;
using Bookmaster.Model;
using Bookmaster.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {


        List<Book> _books = App.context.Book.ToList();
        PaginationService _booksPagination;

        public BrowseCatalogPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchResultsGrid.Visibility = Visibility.Visible;
            if (string.IsNullOrEmpty(SearchbyBookTitleTb.Text) && string.IsNullOrEmpty(SerchbyAuthorNameTb.Text) && string.IsNullOrEmpty(SerchbySubjectTb.Text))
            {
                _booksPagination = new PaginationService(_books);
            }
            else
            {
                List<Book> searchResult = _books.Where(book => book.Title.ToLower().Contains(SearchbyBookTitleTb.Text.ToLower()) && book.Authors.ToLower().Contains(SerchbyAuthorNameTb.Text.ToLower())).ToList();

                _booksPagination = new PaginationService(searchResult);
            }





            // Загружаем данные из таблицы BookAuthor в список ListView.
            BookAuthorLv.ItemsSource = _booksPagination.CurrentPageOfBooks;

            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _booksPagination;

            _booksPagination.UpdatePaginationButtons(PreviousBtn, NextBookBtn);
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.PreviousPage();
            _booksPagination.UpdatePaginationButtons(PreviousBtn, NextBookBtn);
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
        }


        private void NextBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _booksPagination.NextPage();
            _booksPagination.UpdatePaginationButtons(PreviousBtn, NextBookBtn);
            CurrentPageTb.Text = _booksPagination.CurrentPageNumber.ToString();
        }
        private void CurrentPageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CurrentPageTb.Text, out int pageNumber) && pageNumber >= 1 && pageNumber <= _booksPagination.TotalPages)
            {
                BookAuthorLv.ItemsSource = _booksPagination.SetCurrentPage(pageNumber);
            }
            _booksPagination.UpdatePaginationButtons(PreviousBtn, NextBookBtn);
        }

        private void PreviousCoverBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextCoverBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;
            BookDetailsGrid.DataContext = selectedBook;

        }

        private void AuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow();
            bookAuthorsDetailsWindow.ShowDialog();
        }
    }
}
