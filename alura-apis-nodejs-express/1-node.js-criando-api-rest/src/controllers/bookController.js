import { author } from "../models/Autor.js";
import book from "../models/Book.js";

class BookController {

  static async createBook(req, res) {
    const newBook = req.body;
    try {
      const authorFound = await author.findById(newBook.author);
      const completeBook = { ...newBook, author: { ...authorFound._doc }};
      const insertBook = await book.create(completeBook);
      res.status(201).json({ message: "Successfuly registered.", book: insertBook });
    } catch (erro) {
      res.status(500).json({ message: `${erro.message} - failed to register the book` });
    }
  }

  static async getBooks(req, res) {
    try {
      const bookList = await book.find({});
      res.status(200).json(bookList)
    } catch(erro) {
      res.status(500).json({ message: `${erro.message} - request failure` });
    }
  };

  static async getBookById(req, res) {
    try {
      const id = req.params.id;
      const dbBook = await book.findById(id);
      res.status(200).json(dbBook)
    } catch(erro) {
      res.status(500).json({ message: `${erro.message} - book request failure` });
    }
  };

  static async updateBook(req, res) {
    try {
      const id = req.params.id;
      await book.findByIdAndUpdate(id, req.body);
      res.status(200).json({message: "Updated book"})
    } catch(erro) {
      res.status(500).json({ message: `${erro.message} - book request failure` });
    }
  }

  static async deleteBook(req, res) {
    try {
      const id = req.params.id;
      await book.findByIdAndDelete(id);
      res.status(204).json({ message: "Successfully deleted book" });
    } catch (erro) {
      res.status(500).json({ message: `${erro.message} - Deletion failed` });
    }
  };

  static async getBookByPublisher(req, res) {
    const publisher = req.query.publisher;
    try {
      const booksByPublisher = await book.find({ publish_company: publisher });
      res.status(200).json(booksByPublisher);
    } catch (erro) {
      res.status(500).json({ message: `${erro.message} - Search failure` });
    }
  }
};

export default BookController;
