using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class LibraryTests
{
    private List<Visitor> visitors;

    [SetUp]
    public void Setup()
    {
        visitors = new List<Visitor>
        {
            new Visitor { LastName = "������", Privilege = LibraryPrivilege.Standard, BorrowedBooks = new List<Book> { new Book { Title = "����� � ���", IsOverdue = false } } },
            new Visitor { LastName = "������", Privilege = LibraryPrivilege.Premium, BorrowedBooks = new List<Book> { new Book { Title = "������������ � ���������", IsOverdue = true } } }
        };
    }

    [Test]
    public void TestVisitorCreation()
    {
        Visitor newVisitor = new Visitor { LastName = "�������", Privilege = LibraryPrivilege.Standard };
        Assert.AreEqual("�������", newVisitor.LastName);
        Assert.AreEqual(LibraryPrivilege.Standard, newVisitor.Privilege);
        Assert.IsEmpty(newVisitor.BorrowedBooks);
    }

    [Test]
    public void TestBorrowedBooks()
    {
        Visitor newVisitor = new Visitor { LastName = "�������", Privilege = LibraryPrivilege.Premium };
        newVisitor.BorrowedBooks.Add(new Book { Title = "1984", IsOverdue = false });
        Assert.AreEqual(1, newVisitor.BorrowedBooks.Count);
        Assert.AreEqual("1984", newVisitor.BorrowedBooks.First().Title);
        Assert.IsFalse(newVisitor.BorrowedBooks.First().IsOverdue);
    }

    [Test]
    public void TestInformationDisplay()
    {
        try
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main(new string[0]);
                var result = sw.ToString();
                // ����� ����� ��������� �������� ����������� result
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"������ ��� ���������� TestInformationDisplay: {ex.Message}");
        }
    }
}
