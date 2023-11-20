import { Decimal128 } from "mongodb";
import mongoose from "mongoose";
import { authorSchema } from "./Autor.js";

const bookSchema = new mongoose.Schema({
  id: { type: mongoose.Schema.Types.ObjectId },
  title: { type: String, required: true },
  publisher: { type: String },
  price: { type: Decimal128 },
  pages: { type: Number },
  author: authorSchema
}, { versionKey: false });

const book = mongoose.model("books", bookSchema);

export default book;
