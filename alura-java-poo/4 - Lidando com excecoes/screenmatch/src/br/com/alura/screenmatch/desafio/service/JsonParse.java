package br.com.alura.screenmatch.desafio.service;

import br.com.alura.screenmatch.desafio.modelos.Endereco;
import br.com.alura.screenmatch.desafio.modelos.EnderecoDTO;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

public class JsonParse {

    public Gson gson = new GsonBuilder().setPrettyPrinting().create();

    public EnderecoDTO parseToEnderecoDto(String endereco) {
        return gson.fromJson(endereco, EnderecoDTO.class);
    }

    public String parseToJson(List<Endereco> enderecos) {
        return gson.toJson(enderecos);
    }

}
