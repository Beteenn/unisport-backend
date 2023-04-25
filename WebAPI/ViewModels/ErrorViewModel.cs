namespace WebAPI.ViewModels
{
    public class ErrorViewModel
    {
        public string Mensagem { get; set; }

        public ErrorViewModel() { }
        public ErrorViewModel(string mensagem)
        {
            Mensagem = mensagem;
        }
    }

    public class ErrorResponseViewModel
    {
        public IEnumerable<ErrorViewModel> Erros { get; set; }

        public void AddErros(ErrorViewModel erro)
        {
            if (Erros == null)
                Erros = new List<ErrorViewModel>();

            Erros.Append(erro);
        }

        public ErrorResponseViewModel AddErros(string mensagem)
        {
            if (Erros == null)
                Erros = new List<ErrorViewModel>();

            Erros.Append(new ErrorViewModel(mensagem));

            return this;
        }

        public ErrorResponseViewModel AddErros(IEnumerable<ErrorViewModel> erros)
        {
            if (Erros == null)
                Erros = new List<ErrorViewModel>();

            foreach (ErrorViewModel item in erros)
            {
                AddErros(item);
            }

            return this;
        }
    }
}
