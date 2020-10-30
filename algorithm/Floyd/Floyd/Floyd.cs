namespace Floyd
{
    public static class Floyd
    {
        public static readonly double INFINITE = 1.0 / 0.0;
        public static Dist[,] GetFloyd(double[,] G)
        {
            int i, j, v;
            int N = G.GetLength(0);
            Dist[,] D = new Dist[N, N];
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    if (i == j)
                    {
                        D[i, j].length = 0;
                        D[i, j].pre = i;
                    }
                    else
                    {
                        if (G[i, j] != INFINITE)
                        {
                            D[i, j].length = G[i, j];
                            D[i, j].pre = i;
                        }
                        else
                        {
                            D[i, j].length = INFINITE;
                            D[i, j].pre = -1;
                        }
                    }
                }
            }
            //init D
            for (v = 0; v < N; v++)
            {
                for (i = 0; i < N; i++)
                {
                    for (j = 0; j < N; j++)
                    {
                        if (D[i, j].length > (D[i, v].length + D[v, j].length))
                        {
                            D[i, j].length = D[i, v].length + D[v, j].length;
                            D[i, j].pre = D[v, j].pre;
                        }
                    }
                }
            }
            return D;
        }
    }
    public struct Dist
    {
        public double length;
        public int pre;
    }
}
