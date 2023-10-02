package br.com.alura.screenmatch.desafio.principal;

import br.com.alura.screenmatch.desafio.modelos.Endereco;
import br.com.alura.screenmatch.desafio.modelos.EnderecoDTO;
import br.com.alura.screenmatch.desafio.service.JsonParse;
import br.com.alura.screenmatch.desafio.service.CepRequest;

import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Principal {

    public static void main(String[] args) {
        Scanner leia = new Scanner(System.in);
        String cep;
        CepRequest request = new CepRequest();
        JsonParse json = new JsonParse();
        List<Endereco> enderecos = new ArrayList<>();

        do {
            boolean valida = true;
            System.out.print("Digite o cep: ");
            cep = leia.nextLine();

            if (cep.length() != 8 && !cep.equalsIgnoreCase("sair")) {
                System.out.println("O CEP deve conter 8 digitos.");
                valida = false;
            }

            if (cep.equalsIgnoreCase("sair")) {
                break;
            }

            if (valida) {
                String endereco = request.requisitaEndereco(cep);
                EnderecoDTO enderecoDTO = json.parseToEnderecoDto(endereco);
                Endereco novoEndereco = new Endereco(enderecoDTO);
                System.out.println(novoEndereco);

                System.out.print("Deseja guardar o endereco acima (Sim ou Não)? ");
                if (leia.nextLine().equalsIgnoreCase("sim")) {
                    enderecos.add(novoEndereco);
                }

            }






        } while (!cep.equalsIgnoreCase("sair"));

        try {
            FileWriter fileWriter = new FileWriter("enderecos.json");
            fileWriter.write(json.parseToJson(enderecos));
            fileWriter.close();
        } catch (IOException e) {
            System.out.println("Erro na escrita/leitura de arquivo");
        }

    }
}
