const html = document.querySelector('html');
const focoBt = document.querySelector('.app__card-button--foco');
const descansoCurtoBt = document.querySelector('.app__card-button--curto');
const descansoLongoBt = document.querySelector('.app__card-button--longo');
const banner = document.querySelector('.app__image');
const titulo = document.querySelector('.app__title');
const botoes = document.querySelectorAll('.app__card-button');
const startPauseBt = document.querySelector('#start-pause');
const musicaInput = document.querySelector('#alternar-musica');
const musica = new Audio('./sons/luna-rise-part-one.mp3');
const audioPlay = new Audio('./sons/play.wav');
const audioBeep = new Audio('./sons/beep.mp3');
const audioPause = new Audio('./sons/pause.mp3');

let tempoDecorridoEmSeguntos = 5;
let intervaloId = null;

musica.loop = true;

focoBt.addEventListener('click', () => {
    alterarContexto('foco');
    focoBt.classList.add('active');
})

descansoCurtoBt.addEventListener('click', () => {
    alterarContexto('descanso-curto');
    descansoCurtoBt.classList.add('active');
})

descansoLongoBt.addEventListener('click', () => {
    alterarContexto('descanso-longo');
    descansoLongoBt.classList.add('active');
})

musicaInput.addEventListener('change', () => {
    if (musica.paused) {
        musica.play();
    } else {
        musica.pause();
    }
})

function alterarContexto(contexto) {
    html.setAttribute('data-contexto', contexto);
    banner.setAttribute('src', `./imagens/${contexto}.png`)
    botoes.forEach(function (contexto) {
        contexto.classList.remove('active');
    })
    switch (contexto) {
        case "foco":
            titulo.innerHTML = `Otimize sua produtividade, <br> <strong class="app__title-strong"> mergulhe no que importa. </strong>`
            break;
        case "descanso-curto":
            titulo.innerHTML = `Que tal dar uma respirada? <strong class="app__title-strong"> Faça uma pausa curta! </strong>`
            break;
        case "descanso-longo":
            titulo.innerHTML = `Hora de voltar à superfície. <strong class="app__title-strong"> Faça uma pausa longa. </strong>`
            break;
        default:
            break;
    }
}

const contagemRegressiva = () => {
    if (tempoDecorridoEmSeguntos <= 0) {
        audioBeep.play();
        zerarIntervalo();
        alert('Tempo finalizado!');
        return;
    }
    tempoDecorridoEmSeguntos -= 1;
    console.log('Temporizador: ' + tempoDecorridoEmSeguntos)
}

startPauseBt.addEventListener('click', iniciarOuPausarContagem)

function iniciarOuPausarContagem() {
    if (intervaloId) {
        audioPause.play();
        zerarIntervalo();
        return;
    }
    audioPlay.play();
    intervaloId = setInterval(contagemRegressiva, 1000);
}

function zerarIntervalo() {
    clearInterval(intervaloId);
    intervaloId = null;
}