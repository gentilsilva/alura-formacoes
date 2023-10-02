package br.com.alura.screenmatch.desafio.service;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class CepRequest {

    public String requisitaEndereco(String cep) {

        String url = "https://viacep.com.br/ws/" + cep + "/json/";
        String resposta = "";

        try {
            HttpClient client = HttpClient.newHttpClient();
            HttpRequest request = HttpRequest.newBuilder().uri(URI.create(url)).build();
            HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
            resposta = response.body();

        } catch (IOException e) {
            System.out.println("Endereço incorreto");
            System.out.println(e.getMessage());

        } catch (InterruptedException e) {
            System.out.println("Tempo de execução excedido.");
            System.out.println(e.getMessage());
        }

        return resposta;

    }

}
