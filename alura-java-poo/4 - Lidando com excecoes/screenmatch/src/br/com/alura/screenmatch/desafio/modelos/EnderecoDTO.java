package br.com.alura.screenmatch.desafio.modelos;

public record EnderecoDTO(
        String cep,
        String logradouro,
        String bairro,
        String localidade,
        String uf,
        String ibge,
        String ddd
) {
}
