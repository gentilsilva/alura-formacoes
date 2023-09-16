const form = document.getElementById('novoItem')
const lista = document.getElementById("lista")
const itens = JSON.parse(localStorage.getItem("itens")) || []

itens.forEach( (elemento) => {
    cadastraElemento(elemento)
})


form.addEventListener("submit", (evento) => {
    evento.preventDefault()

    const nome = evento.target.elements['nome']
    const quantidade = evento.target.elements['quantidade']

    const existe = itens.find(elemento => elemento.nome === nome.value)

    const itemAtual = {             // Transforma os dados passado em um objeto
        "nome" : nome.value,
        "quantidade" : quantidade.value
    }

    if(existe) {                                // Verifica se existe um id. Se existe, atualiza a quantidade, se não existe, cria um novo elemento
        itemAtual.id = existe.id                        
        atualizaElemento(itemAtual)
    } else {
        itemAtual.id = itens.length
        cadastraElemento(itemAtual)  // Pega os elementos nome e quantidade do html
        itens.push(itemAtual)
    }

    localStorage.setItem("itens", JSON.stringify(itens))    /* Registra o nome entre outros no localStorage do navegador. 
                                                                localStorage só armazena dados do tipo string. novoItem sendo um objeto, precisamos usar do JSON para transformar em uma string */

    nome.value = ""
    quantidade.value = ""
})


function cadastraElemento(item) {
    const novoItem = document.createElement("li")   // cria tag li entre outras tags
    novoItem.classList.add("item")    // Adicionana a class item no item criado, pois é a classe que está no html

    const numeroItem = document.createElement('strong')
    numeroItem.innerHTML = item.quantidade
    numeroItem.dataset.id = item.id

    novoItem.appendChild(numeroItem)  // coloca um item dentro de outro, nesse caso, o numeroItem vai para dentro da lista novoItem
    novoItem.innerHTML += item.nome

    lista.appendChild(novoItem)
}

function atualizaElemento(item) {
    document.querySelector("[data-id='"+item.id+"']").innerHTML = item.quantidade
}
