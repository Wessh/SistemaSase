//Categoria Vigilante
    function CatVig() {
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
    function CatPor() {
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