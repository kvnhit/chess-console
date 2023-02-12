using xadrez_console;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.linha = pos.linha - 1;
            }

            // abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.linha = pos.linha + 1;
            }

            // abaixo
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.coluna = pos.coluna + 1;
            }

            // abaixo
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                    break;
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }
    }
}
