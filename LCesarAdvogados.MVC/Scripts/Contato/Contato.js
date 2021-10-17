$(document).ready(function () {   
    $("#bnt_Contato").click(function () {

        $("#DivLoading").css('display', 'block');

        var Nome = $("#txt_name").val();
        var Email = $("#txt_email").val();
        var Assunto = $("#txt_subject").val();
        var Mensagem = $("#txt_message").val();

        if (Nome != "" && Email != "" && Assunto != "" && Mensagem != "") {
            $.ajax(
            {
                type: 'POST',
                url: '/Home/EnviarContato',
                cache: false,
                data: { 'Nome': Nome, 'Email': Email, 'Assunto': Assunto, 'Mensagem': Mensagem },
                cache: false,
                async: true,
                success: function (data) {
                    if (data.MsgSucesso != "") {
                        $("#DivLoading").css('display', 'none');
                        $("#DivFeedbackUser").empty();
                        $("#DivFeedbackUser").append("<p class=\"alert alert-info\">Mensagem enviada com sucesso. Nossa equipe entrará em contato em breve.</p>");
                    }
                    else {
                        $("#DivLoading").css('display', 'none');
                        $("#DivFeedbackUser").empty();
                        $("#DivFeedbackUser").append("<p class=\"alert alert-danger\">Houve uma falha ao enviar o email.</p>");
                    }
                },
                error: function () {
                    alert("Houve uma falha ao enviar seu email");
                }
            });
        }
        else {
            $("#DivLoading").css('display', 'none');
            if (Nome == "")
                $("#txt_name").addClass("Erro");
            if (Email == "")
                $("#txt_email").addClass("Erro");
            if (Assunto == "")
                $("#txt_subject").addClass("Erro");
            if (Mensagem == "")
                $("#txt_message").addClass("Erro");

            $("#DivErro").empty();
            $("#DivErro").append("<p class=\"alert alert-danger\">Preencha todos os campos</p>");
        }
    });

    $("#txt_name").click(function () {
        $("#txt_name").removeClass("Erro");
    });
    $("#txt_email").click(function () {
        $("#txt_email").removeClass("Erro");
    });
    $("#txt_subject").click(function () {
        $("#txt_subject").removeClass("Erro");
    });
    $("#txt_message").click(function () {
        $("#txt_message").removeClass("Erro");
    });
});
