﻿using Library.Models;
using Library.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
  public partial class LibraryForm : Form
  {

    BookService bookService;

    public LibraryForm()
    {
      InitializeComponent();

      // we create only one context in our application, which gets shared among repositories
      LibraryContext context = new LibraryContext();
      // we use a factory object that will create the repositories as they are needed, it also makes
      // sure all the repositories created use the same context.
      RepositoryFactory repFactory = new RepositoryFactory(context);

      this.bookService = new BookService(repFactory);

      ShowAllBooks(bookService.All());
    }


    private void ShowAllBooks(IEnumerable<Book> books)
    {
      lbBooks.Items.Clear();
      foreach (Book book in books) {
        lbBooks.Items.Add(book.Title + " " + " [5]");
      }
    }

    

    

    private void LibraryForm_Load(object sender, EventArgs e)
    {

    }

    private void testBtn_Click(object sender, EventArgs e)
    {

    }
  }
}
