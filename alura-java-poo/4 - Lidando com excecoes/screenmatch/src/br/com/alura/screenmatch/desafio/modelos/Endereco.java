package br.com.alura.screenmatch.desafio.modelos;

public class Endereco {

    private String cep;
    private String logradouro;
    private String bairro;
    private String localidade;
    private String uf;
    private String ibge;
    private String ddd;

    public Endereco(EnderecoDTO enderecoDTO) {
        this.cep = enderecoDTO.cep();;
        this.logradouro = enderecoDTO.logradouro();
        this.bairro = enderecoDTO.bairro();
        this.localidade = enderecoDTO.localidade();
        this.uf = enderecoDTO.uf();
        this.ibge = enderecoDTO.ibge();
        this.ddd = enderecoDTO.ddd();
    }

    @Override
    public String toString() {
        return "{" +
                "cep = '" + cep +
                ", logradouro = " + logradouro +
                ", bairro = " + bairro +
                ", localidade = " + localidade +
                ", uf = " + uf +
                ", ibge = " + ibge +
                ", ddd = " + ddd +
                '}';
    }
}
