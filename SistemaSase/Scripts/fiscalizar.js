//Hide
var checkP = document.getElementById("PQS");
var checkC = document.getElementById("CO2");
var checkA = document.getElementById("CheckAgua");
if (checkP.checked == false) {
    var dataVal = document.getElementById("DatePQS");
    dataVal.value = "2000-01-01";
}
if (checkC.checked == false) {
    var dataVal = document.getElementById("DateCO2");
    dataVal.value = "2000-01-01";
}
if (checkA.checked == false) {
    var dataVal = document.getElementById("DateAgua");
    dataVal.value = "2000-01-01";
}
//Categoria Vigilante
function fCatVig() {
    var checkBox = document.getElementById("CatVig");
    if (checkBox.checked == true) {
        $("#EqpVig").slideDown().fadeTo(100, 100).removeClass('hidden');
    } else {
        $("#EqpVig").slideUp().fadeTo(100, 100,
            function () {
                $("#EqpVig").addClass('hidden');
            });
    }
};
//Categoria Porteiro
function fCatPor() {
    var checkBox = document.getElementById("CatPor");
    if (checkBox.checked == true) {
        $("#EqpPor").slideDown().fadeTo(100, 100).removeClass('hidden');
    } else {
        $("#EqpPor").slideUp().fadeTo(100, 100,
            function () {
                $("#EqpPor").addClass('hidden');
            });
    }
};

/** -- **/

//Iluminação Interna
function IluInt() {
    var checkBox = document.getElementById("InternaIlu");
    if (checkBox.checked == true) {
        $("#IluInt").slideDown().fadeTo(100, 100).removeClass('hidden');
    } else {
        $("#IluInt").slideUp().fadeTo(100, 100,
            function () {
                $("#IluInt").addClass('hidden');
            });
    }
};
//Iluminação Externa
function IluExt() {
    var checkBox = document.getElementById("ExternaIlu");
    if (checkBox.checked == true) {
        $("#IluExt").slideDown().fadeTo(100, 100).removeClass('hidden');
    } else {
        $("#IluExt").slideUp().fadeTo(100, 100,
            function () {
                $("#IluExt").addClass('hidden');
            });
    }
};

/** -- **/

//Extintor
function Ext() {
    var checkBox = document.getElementById("ExtSel");
    if (checkBox.checked == true) {
        $("#DivExtintores").slideDown().fadeTo(100, 100).removeClass('hidden');
    } else {
        $("#DivExtintores").slideUp().fadeTo(100, 100,
            function () {
                $("#DivExtintores").addClass('hidden');
            });
    }
};
//Tipo PQS
function fPQS() {
    var checkBox = document.getElementById("PQS");
    var dataVal = document.getElementById("DatePQS");
    if (checkBox.checked == true) {
        $("#DatePQS").slideDown().fadeTo(100, 100).removeClass('hidden');
        dataVal.value = "";
    } else {
        $("#DatePQS").slideUp().fadeTo(100, 100,
            function () {
                $("#DatePQS").addClass('hidden');
                dataVal.value = "2000-01-01";
            });
    }
};
//Tipo CO2
function fCO2() {
    var checkBox = document.getElementById("CO2");
    var dataVal = document.getElementById("DateCO2");
    if (checkBox.checked == true) {
        $("#DateCO2").slideDown().fadeTo(100, 100).removeClass('hidden');
        dataVal.value = "";
    } else {
        $("#DateCO2").slideUp().fadeTo(100, 100,
            function () {
                $("#DateCO2").addClass('hidden');
                dataVal.value = "2000-01-01";
            });
    }
};
//Tipo AGUA
function fAgF() {
    var checkBox = document.getElementById("CheckAgua");
    var dataVal = document.getElementById("DateAgua");
    if (checkBox.checked == true) {
        $("#DateAgua").slideDown().fadeTo(100, 100).removeClass('hidden');
        dataVal.value = "";
        
    } else {
        $("#DateAgua").slideUp().fadeTo(100, 100,
            function () {
                $("#DateAgua").addClass('hidden');
                dataVal.value = "2000-01-01";
            });
    }
};

/** -- **/

//Tipo Gás Cozinha

//Gás Industrial
function fGInd() {
    var checkBox = document.getElementById("GInd");
    if (checkBox.checked == true) {
        $("#IndFun").slideDown().fadeTo(100, 100).removeClass('hidden');
    } else {
        $("#IndFun").slideUp().fadeTo(100, 100,
            function () {
                $("#IndFun").addClass('hidden');
            });
    }
};


//Gás Doméstico
function fGDom() {
    var checkBox = document.getElementById("GDom");
    if (checkBox.checked == true) {
        $("#DomFun").slideDown().fadeTo(100, 100).removeClass('hidden');
    } else {
        $("#DomFun").slideUp().fadeTo(100, 100,
            function () {
                $("#DomFun").addClass('hidden');
            });
    }
};

//Botão de envio
function bntEnviar() {
    //Verificar QNT Postos
    var pV = document.getElementById("PostVigilante");
    if (pV.value.length < 1) {
        $("#PostVigilante").val(0);
    }
    var pV = document.getElementById("PostPorteiro");
    if (pV.value.length < 1) {
        $("#PostPorteiro").val(0);
    }
    var pV = document.getElementById("PostVigia");
    if (pV.value.length < 1) {
        $("#PostVigia").val(0);
    }
    
}