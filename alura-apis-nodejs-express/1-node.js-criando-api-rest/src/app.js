import express from "express";
import connectToDatabase from "./config/dbConnect.js";
import routes from "./routes/index.js";

const connection = await connectToDatabase();

connection.on("error", (erro) => {
  console.error("connection error", erro);
});

connection.once("open", () => {
  console.log("Connection to the database made succesfully.");
})

const app = express();
routes(app);

export default app;
