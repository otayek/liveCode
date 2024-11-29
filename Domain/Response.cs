namespace liveCodeBFF.Domain
{
    public class Response
    {
        public string trace_id { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Cartao[] cartoes { get; set; }
    }

    public class Cartao
    {
        public string numero { get; set; }
        public string codigo_seguranca { get; set; }
        public int limite { get; set; }
        public string validade { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public bool legado { get; set; }
        public string bandeira { get; set; }
    }
}
