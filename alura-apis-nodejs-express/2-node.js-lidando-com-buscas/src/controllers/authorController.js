import mongoose from "mongoose";
import { author } from "../models/Autor.js";

class AuthorController {

  static async createAuthor(req, res) {
    try {
      const newAuthor = await author.create(req.body);
      res.status(201).json({ message: "Successfuly registered.", author: newAuthor });
    } catch (erro) {
      res.status(500).json({ message: `${erro.message} - failed to register the author.` });
    }
  }

  static async getAuthors(req, res) {
    try {
      const authorList = await author.find({});
      res.status(200).json(authorList);
    } catch(erro) {
      res.status(500).json({ message: `${erro.message} - request failure.` });
    }
  }

  static async getAuthorById(req, res) {
    try {
      const id = req.params.id;
      const dbAuthor = await author.findById(id);

      if(dbAuthor !== null) {
        res.status(200).json(dbAuthor);
      } else {
        res.status(404).json({ message: "author not found." });
      }
    } catch(erro) {
      if(erro instanceof mongoose.Error.CastError) {
        res.status(400).send({ message: "Incorrect data provided."});
      } else {
        res.status(500).send( { message: `${erro.message} - Internal error.` });
      }
    }
  }

  static async updateAuthor(req, res) {
    try {
      const id = req.params.id;
      await author.findByIdAndUpdate(id, req.body);
      res.status(200).json({message: "Updated author."});
    } catch(erro) {
      res.status(500).json({ message: `${erro.message} - author request failure.` });
    }
  }

  static async deleteAuthor(req, res) {
    try {
      const id = req.params.id;
      await author.findByIdAndDelete(id);
      res.status(204).json({ message: "Successfully deleted author." });
    } catch (erro) {
      res.status(500).json({ message: `${erro.message} - Deletion failed.` });
    }
  }
}

export default AuthorController;
