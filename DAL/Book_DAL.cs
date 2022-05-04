using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using TestBaiThi1.Models;

namespace TestBaiThi1.DAL
{
    public class Book_DAL
    {
        public SqlConnection ketnoi()
        {
            string st = ConfigurationManager.ConnectionStrings["KetNoiDataBase"].ToString();
            SqlConnection con = new SqlConnection(st);
            return con;
        }

        public List<Book> ListBooks()
        {
            List<Book> books = new List<Book>();
            SqlConnection con = ketnoi();
            con.Open();
            string st = "SELECT *FROM Book1";
            SqlCommand cm = new SqlCommand(st, con);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                Book b = new Book();
                b.ID = int.Parse(dr["ID"].ToString());
                b.TenSach = dr["TenSach"].ToString();
                b.TacGia = dr["TacGia"].ToString();
                b.NamXB = dr["NamXB"].ToString();
                b.ImageCover = dr["ImageCover"].ToString();
                books.Add(b);

            }
            con.Close();
            return books;

        }
        public void AddBook(Book b)
        {
            List<Book> books = new List<Book>();
            SqlConnection con = ketnoi();
            con.Open();
            string st = "INSERT INTO Book1 VALUES(@ID,@TenSach,@TacGia,@NamXB,@ImageCover)";
            SqlCommand cm = new SqlCommand(st, con);
            cm.Parameters.AddWithValue("ID", b.ID);
            cm.Parameters.AddWithValue("TenSach", b.TenSach);
            cm.Parameters.AddWithValue("TacGia", b.TacGia);
            cm.Parameters.AddWithValue("NamXB", b.NamXB);
            cm.Parameters.AddWithValue("ImageCover", b.ImageCover);
            cm.ExecuteNonQuery();
            con.Close();
           
        }

        internal string ListBook()
        {
            throw new NotImplementedException();
        }

        public void EditBook(Book b)
        {
            List<Book> books = new List<Book>();
            SqlConnection con = ketnoi();
            con.Open();
            string st = "UPDATE Book1 SET TenSach=@TenSach,TacGia=@TacGia,NamXB=@NamXB,ImageCover=@ImageCover where ID = @ID";
            SqlCommand cm = new SqlCommand(st, con);
            cm.Parameters.AddWithValue("ID", b.ID);
            cm.Parameters.AddWithValue("TenSach", b.TenSach);
            cm.Parameters.AddWithValue("TacGia", b.TacGia);
            cm.Parameters.AddWithValue("NamXB", b.NamXB);
            cm.Parameters.AddWithValue("ImageCover", b.ImageCover);
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteBook(int ID)
        {
            SqlConnection con = ketnoi();
            con.Open();
            string st = "DELETE Book1 WHERE ID = @ID";
            SqlCommand cm = new SqlCommand(st, con);
            cm.Parameters.AddWithValue("ID",ID);
            cm.ExecuteNonQuery();
            con.Close();
        }

    }
}