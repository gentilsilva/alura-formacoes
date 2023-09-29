package br.com.alura.screenmatch.desafio.modelos;

public class Endereco {

    private String cep;
    private String logradouro;
    private String complemento;
    private String bairro;
    private String localidade;
    private String uf;
    private String ibge;
    private String gia;
    private String ddd;
    private String siafi;

    public Endereco(EnderecoDTO enderecoDTO) {
        this.cep = enderecoDTO.cep();;
        this.logradouro = enderecoDTO.logradouro();
        this.complemento = enderecoDTO.complemento();
        this.bairro = enderecoDTO.bairro();
        this.localidade = enderecoDTO.localidade();
        this.uf = enderecoDTO.uf();
        this.ibge = enderecoDTO.ibge();
        this.gia = enderecoDTO.gia();
        this.ddd = enderecoDTO.ddd();
        this.siafi = enderecoDTO.siafi();
    }

    @Override
    public String toString() {
        return "{" +
                "cep = '" + cep +
                ", logradouro = " + logradouro +
                ", complemento = " + complemento +
                ", bairro = " + bairro +
                ", localidade = " + localidade +
                ", uf = " + uf +
                ", ibge = " + ibge +
                ", gia = " + gia +
                ", ddd = " + ddd +
                ", siafi = " + siafi +
                '}';
    }
}
