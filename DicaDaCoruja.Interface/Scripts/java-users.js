// Calendario para TextDataInicio
$(document).ready(function (e) {
    $("input[id$='TextDataInicio']").datepicker({
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        dateFormat: 'dd/mm/yy',
        nextText: 'Próximo',
        prevText: 'Anterior',
    });
});
// Calendario para TextDataFim
$(document).ready(function (e) {
    $("input[id$='TextDataFim']").datepicker({
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        dateFormat: 'dd/mm/yy',
        nextText: 'Próximo',
        prevText: 'Anterior',
    });
});
// Ajusta tamanho da div pelo DivGridView
$(document).ready(function () {
    var winW = $(window).width();
    winW = winW * 0.958;
    var divResize = $(".DivGridView");
    divResize.css('width', winW);
});
$(function () {
    $(window).resize(function () {
        var winW = $(window).width();
        winW = winW * 0.958;
        var divResize = $(".DivGridView");
        divResize.css('width', winW);
    });
});
// Formata os campos de acordo com as mascaras
function formataValor(campo, evt) {
    // 00000.00
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        vr = parseFloat(vr.toString()).toString();
        tam = vr.length;
        if (tam == 1)
            campo.value = "0.0" + vr;
        if (tam == 2)
            campo.value = "0." + vr;
        if (tam > 2) {
            campo.value = vr.substr(0, tam - 2) + '.' + vr.substr(tam - 2, tam);
        }
    }
    MovimentaCursor(campo, xPos);
}
function formataData(campo, evt) {
    // DD/MM/AAAA
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;
    if (tam >= 2 && tam < 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2);
    if (tam == 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/';
    if (tam > 4)
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4);
    MovimentaCursor(campo, xPos);
}
function formataCNPJ(campo, evt) {
    //99.999.999/9999-99
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;
    if (tam >= 2 && tam < 5)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2);
    else if (tam >= 5 && tam < 8)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5);
    else if (tam >= 8 && tam < 12)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5, 3) + '/' + vr.substr(8);
    else if (tam >= 12)
        campo.value = vr.substr(0, 2) + '.' + vr.substr(2, 3) + '.' + vr.substr(5, 3) + '/' + vr.substr(8, 4) + '-' + vr.substr(12);
    MovimentaCursor(campo, xPos);
}
function formataCPF(campo, evt) {
    //999.999.999-99
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;
    if (tam >= 3 && tam < 6)
        campo.value = vr.substr(0, 3) + '.' + vr.substr(3);
    else if (tam >= 6 && tam < 9)
        campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(6);
    else if (tam >= 9)
        campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(6, 3) + '-' + vr.substr(9);
    MovimentaCursor(campo, xPos);
}
function formataTelefone(campo, evt) {
    //(00) 0000-0000
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;
    if (tam == 1)
        campo.value = '(' + vr;
    else if (tam >= 2 && tam < 6)
        campo.value = '(' + vr.substr(0, 2) + ') ' + vr.substr(2);
    else if (tam >= 6)
        campo.value = '(' + vr.substr(0, 2) + ') ' + vr.substr(2, 4) + '-' + vr.substr(6);
    //(
    //    if(xPos == 1 || xPos == 3 || xPos == 5 || xPos == 9)
    //        xPos = xPos +1
    MovimentaCursor(campo, xPos);
}
function formataCEP(campo, evt) {
    //00000-000
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    vr = campo.value = filtraNumeros(filtraCampo(campo));
    tam = vr.length;
    if (tam < 5)
        campo.value = vr;
    else if (tam == 5)
        campo.value = vr + '-';
    else if (tam > 5)
        campo.value = vr.substr(0, 5) + '-' + vr.substr(5);
    MovimentaCursor(campo, xPos);
}
function formataCartaoCredito(campo, evt) {
    //0000.0000.0000.0000
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;
    var vr = campo.value = filtraNumeros(filtraCampo(campo));
    var tammax = 16;
    var tam = vr.length;
    if (tam < tammax && tecla != 8)
    { tam = vr.length + 1; }
    if (tam < 5)
    { campo.value = vr; }
    if ((tam > 4) && (tam < 9))
    { campo.value = vr.substr(0, 4) + '.' + vr.substr(4, tam - 4); }
    if ((tam > 8) && (tam < 13))
    { campo.value = vr.substr(0, 4) + '.' + vr.substr(4, 4) + '.' + vr.substr(8, tam - 4); }
    if (tam > 12)
    { campo.value = vr.substr(0, 4) + '.' + vr.substr(4, 4) + '.' + vr.substr(8, 4) + '.' + vr.substr(12, tam - 4); }
    MovimentaCursor(campo, xPos);
}
//descobre qual a posição do cursor no campo
function PosicaoCursor(textarea) {
    var pos = 0;
    if (typeof (document.selection) != 'undefined') {
        //IE
        var range = document.selection.createRange();
        var i = 0;
        for (i = textarea.value.length; i > 0; i--) {
            if (range.moveStart('character', 1) == 0)
                break;
        }
        pos = i;
    }
    if (typeof (textarea.selectionStart) != 'undefined') {
        //FireFox
        pos = textarea.selectionStart;
    }
    if (pos == textarea.value.length)
        return 0; //retorna 0 quando não precisa posicionar o elemento
    else
        return pos; //posição do cursor
}
// move o cursor para a posição pos
function MovimentaCursor(textarea, pos) {
    if (pos <= 0)
        return; //se a posição for 0 não reposiciona
    if (typeof (document.selection) != 'undefined') {
        //IE
        var oRange = textarea.createTextRange();
        var LENGTH = 1;
        var STARTINDEX = pos;
        oRange.moveStart("character", -textarea.value.length);
        oRange.moveEnd("character", -textarea.value.length);
        oRange.moveStart("character", pos);
        //oRange.moveEnd("character", pos);
        oRange.select();
        textarea.focus();
    }
    if (typeof (textarea.selectionStart) != 'undefined') {
        //FireFox
        textarea.selectionStart = pos;
        textarea.selectionEnd = pos;
    }
}
// limpa todos os caracteres especiais do campo solicitado
function filtraCampo(campo) {
    var s = "";
    var cp = "";
    vr = campo.value;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) != "/"
            && vr.substring(i, i + 1) != "-"
            && vr.substring(i, i + 1) != "."
            && vr.substring(i, i + 1) != "("
            && vr.substring(i, i + 1) != ")"
            && vr.substring(i, i + 1) != ":"
            && vr.substring(i, i + 1) != ",") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
    //return campo.value.replace("/", "").replace("-", "").replace(".", "").replace(",", "")
}
// limpa todos caracteres que não são números
function filtraNumeros(campo) {
    var s = "";
    var cp = "";
    vr = campo;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) == "0" ||
            vr.substring(i, i + 1) == "1" ||
            vr.substring(i, i + 1) == "2" ||
            vr.substring(i, i + 1) == "3" ||
            vr.substring(i, i + 1) == "4" ||
            vr.substring(i, i + 1) == "5" ||
            vr.substring(i, i + 1) == "6" ||
            vr.substring(i, i + 1) == "7" ||
            vr.substring(i, i + 1) == "8" ||
            vr.substring(i, i + 1) == "9") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
    //return campo.value.replace("/", "").replace("-", "").replace(".", "").replace(",", "")
}
// limpa todos caracteres que não são letras
function filtraCaracteres(campo) {
    vr = campo;
    for (i = 0; i < tam; i++) {
        //Caracter
        if (vr.charCodeAt(i) != 32 && vr.charCodeAt(i) != 94 && (vr.charCodeAt(i) < 65 ||
            (vr.charCodeAt(i) > 90 && vr.charCodeAt(i) < 96) ||
            vr.charCodeAt(i) > 122) && vr.charCodeAt(i) < 192) {
            vr = vr.replace(vr.substr(i, 1), "");
        }
    }
    return vr;
}
// limpa todos caracteres que não são números, menos a vírgula
function filtraNumerosComVirgula(campo) {
    var s = "";
    var cp = "";
    vr = campo;
    tam = vr.length;
    var complemento = 0; //flag paga contar o número de virgulas
    for (i = 0; i < tam; i++) {
        if ((vr.substring(i, i + 1) == "," && complemento == 0 && s != "") ||
            vr.substring(i, i + 1) == "0" ||
            vr.substring(i, i + 1) == "1" ||
            vr.substring(i, i + 1) == "2" ||
            vr.substring(i, i + 1) == "3" ||
            vr.substring(i, i + 1) == "4" ||
            vr.substring(i, i + 1) == "5" ||
            vr.substring(i, i + 1) == "6" ||
            vr.substring(i, i + 1) == "7" ||
            vr.substring(i, i + 1) == "8" ||
            vr.substring(i, i + 1) == "9") {
            if (vr.substring(i, i + 1) == ",")
                complemento = complemento + 1;
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;
}
//recupera tecla e evita criar mascara quando as teclas são pressionadas
function teclaValida(tecla) {
    if (tecla == 8 //backspace
        //Esta evitando o post, quando são pressionadas estas teclas.
        //Foi comentado pois, se for utilizado o evento texchange, é necessario o post.
        || tecla == 9 //TAB
        || tecla == 27 //ESC
        || tecla == 16 //Shif TAB 
        || tecla == 45 //insert
        || tecla == 46 //delete
        || tecla == 35 //home
        || tecla == 36 //end
        || tecla == 37 //esquerda
        || tecla == 38 //cima
        || tecla == 39 //direita
        || tecla == 40)//baixo
        return false;
    else
        return true;
}
// recupera o evento do form
function getEvent(evt) {
    if (!evt) evt = window.event; //IE
    return evt;
}
//Recupera o código da tecla que foi pressionado
function getKeyCode(evt) {
    var code;
    if (typeof (evt.keyCode) == 'number')
        code = evt.keyCode;
    else if (typeof (evt.which) == 'number')
        code = evt.which;
    else if (typeof (evt.charCode) == 'number')
        code = evt.charCode;
    else
        return 0;
    return code;
}
