package br.com.alura.screenmatch.desafio.service;

import br.com.alura.screenmatch.desafio.modelos.Endereco;

import java.io.FileWriter;
import java.io.IOException;
import java.util.List;

public class FileGenerate {

    public void GenerateFile(List<Endereco> enderecos, JsonParse json) {

        {
            try {
                FileWriter fileWriter = new FileWriter("enderecos.json");
                fileWriter.write(json.parseToJson(enderecos));
                fileWriter.close();
            } catch (IOException e) {
                System.out.println("Erro na escrita/leitura de arquivo");
                System.out.println(e.getMessage());
            }
        }
    }

}
