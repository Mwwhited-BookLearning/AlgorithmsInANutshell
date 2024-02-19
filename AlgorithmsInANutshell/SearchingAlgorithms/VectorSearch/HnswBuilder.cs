//namespace SearchingAlgorithms.VectorSearch;

//public interface IHnswGraph
//{
//    IHnswNode EntryPoint { get; }
//}
//public interface IHnswNode
//{
//    int Level { get; }
//}

///// <summary>
///// https://arxiv.org/ftp/arxiv/papers/1603/1603.09320.pdf
///// </summary>
//public class HnswBuilder
//{
//    private readonly Random _rand = new();

//    private IHnswNode GetNearest<TQ>(ICollection<TQ> w, TQ? q) => throw new NotImplementedException();
//    private object Neighborhood<TQ>(TQ e, int lc) => throw new NotImplementedException();


//    /// <summary>
//    /// Algorithm 1 
//    /// INSERT(hnsw, q, M, Mmax, efConstruction, mL) 
//    /// Input: 
//    ///     multilayer graph hnsw, 
//    ///     new element q, 
//    ///     number of established connections M, 
//    ///     maximum number of connections for each element per layer Mmax, 
//    ///     size of the dynamic candidate list efConstruction, 
//    ///     normalization factor for level generation mL 
//    /// Output:
//    ///     update hnsw inserting element q 
//    /// </summary>
//    /// <typeparam name="TQ"></typeparam>
//    /// <param name="hnsw">multilayer graph</param>
//    /// <param name="q">new element</param>
//    /// <param name="M">number of established connections</param>
//    /// <param name="Mmax">maximum number of connections for each element per layer</param>
//    /// <param name="efConstruction">size of the dynamic candidate list</param>
//    /// <param name="mL">normalization factor for level generation</param>
//    /// <returns>update hnsw inserting element</returns>
//    public IHnswGraph Insert<TQ>(
//        IHnswGraph hnsw,
//        TQ q,
//        int M,
//        int Mmax,
//        int efConstruction,
//        double mL
//        )
//    {
//        //1  W ← ∅    // list for the currently found nearest elements 
//        List<TQ> W = [];

//        //2  ep ← get enter point for hnsw 
//        var ep = hnsw.EntryPoint;

//        //3  L ← level of ep    // top layer for hnsw 
//        int L = ep.Level;

//        //4  l ← ⌊-ln(unif(0..1))∙mL⌋  // new element’s level     
//        int l = (int)Math.Floor(-Math.Log(_rand.NextDouble()) * mL);

//        //5  for lc ← L … l+1 
//        for (var lc = L; lc < l + 1; l--)
//        {
//            //6     W ← SEARCH-LAYER(q, ep, ef=1, lc) 
//            W = [.. SearchLayer(q, ep, ef: 1, lc)];
//            //7     ep ← get the nearest element from W to q 
//            ep = GetNearest(W, q);
//        }

//        //8  for lc ← min(L, l) … 0 
//        for (var lc = Math.Min(L, l); lc > 0; lc--)
//        {
//            //9      W ← SEARCH-LAYER(q, ep, efConstruction, lc) 
//            W = [.. SearchLayer(q, ep, ef: 1, lc)];

//            //10    neighbors ← SELECT-NEIGHBORS(q, W, M, lc) // alg. 3 or alg. 4 
//            var neighbors = SelectNeighbors(q, W, M, lc);

//            //11    add bidirectional connections from neighbors to q at layer lc 
//            //TODO: !!!add connections!!!

//            //12    for each e ∈ neighbors   // shrink connections if needed 
//            foreach (var e in neighbors)
//            {
//                //13       eConn ← neighbourhood(e) at layer lc    
//                var eConn = Neighborhood(e, lc);

//                //14       if │eConn│ > Mmax // shrink connections of e 
//                //                           // if lc = 0 then Mmax = Mmax0 

//                //15          eNewConn ← SELECT-NEIGHBORS(e, eConn,  Mmax, lc)  // alg. 3 or alg. 4 
//                var eNewConn = SelectNeighbors(q, W, M, lc);

//                //16          set neighbourhood(e) at layer lc to eNewConn 
//            }

//            //17    ep ← W 
//            //TODO: fix this ? ep = W;
//        }

//        //18 if l > L 
//        //19    set enter point for hnsw to q 

//        throw new NotImplementedException();
//    }

//    public TQ[] SearchLayer<TQ>(TQ q, IHnswNode ep, int ef, int lc)
//    {
//        //Algorithm 2 
//        //SEARCH-LAYER(q, ep, ef, lc) 
//        //Input: query element q, enter points ep, number of nearest to q ele
//        //ments to return ef, layer number lc 
//        //Output: ef closest neighbors to q 
//        //1  v ← ep      // set of visited elements 
//        //2  C ← ep     // set of candidates  
//        //3  W ← ep    // dynamic list of found nearest neighbors 
//        //4  while │C│ > 0 
//        //5     c ← extract nearest element from C to q 
//        //6     f ← get furthest element from W to q 
//        //7     if distance(c, q) > distance(f, q) 
//        //8        break   // all elements in W are evaluated 
//        //9     for each e ∈ neighbourhood(c) at layer lc   // update C and W 
//        //10        if e ∉ v 
//        //11          v ← v ⋃ e 
//        //12          f ← get furthest element from W to q 
//        //13          if distance(e, q) < distance(f, q) or │W│ < ef 
//        //14             C ← C ⋃ e 
//        //15             W ← W ⋃ e  
//        //16             if │W│ > ef 
//        //17                remove furthest element from W to q  
//        //18 return W 
//        throw new NotImplementedException();
//    }

//    public TQ[] SelectNeighbors<TQ>(TQ? q, List<TQ> w, int m, int lc) =>
//        throw new NotImplementedException();

//    //Algorithm 3 
//    //SELECT-NEIGHBORS-SIMPLE(q, C, M)
//    //Input: base element q, candidate elements C, number of neighbors to 
//    //return M
//    //    Output: M nearest elements to q   
//    //return M nearest elements from C to q

//    //Algorithm 4 
//    //SELECT-NEIGHBORS-HEURISTIC(q, C, M, lc, extendCandidates, keep PrunedConnections)
//    //Input:
//    //  base element q,
//    //  candidate elements C, number of neighbors to return M,
//    //  layer number lc,
//    //  flag indicating whether or not to extend candidate list extendCandidates,
//    //  flag indicating whether or not to add discarded elements keepPrunedConnections
//    //Output: M elements selected by the heuristic 
//    //1  R ← ∅ 
//    //2  W ← C   // working queue for the candidates 
//    //3  if extendCandidates   // extend candidates by their neighbors 
//    //4    for each e ∈ C 
//    //5       for each eadj ∈ neighbourhood(e) at layer lc 
//    //6          if eadj ∉ W 
//    //7             W ← W ⋃ eadj 
//    //8  Wd ← ∅   // queue for the discarded candidates 
//    //9  while │W│ > 0 and │R│< M 
//    //10    e ← extract nearest element from W to q  
//    //11    if e is closer to q compared to any element from R 
//    //12       R ← R ⋃ e 
//    //13    else 
//    //14       Wd ← Wd ⋃ e 
//    //15  if keepPrunedConnections  // add some of the discarded 
//    //                                                   // connections from Wd 
//    //16    while │Wd│> 0 and │R│< M 
//    //17       R ← R ⋃ extract nearest element from Wd to q  
//    //18 return R

//    //Algorithm 5 
//    //K-NN-SEARCH(hnsw, q, K, ef)
//    //Input: multilayer graph hnsw, query element q, number of nearest
//    //neighbors to return K, size of the dynamic candidate list ef
//    //Output: K nearest elements to q 
//    //1  W ← ∅   // set for the current nearest elements 
//    //2  ep ← get enter point for hnsw 
//    //3  L ← level of ep    // top layer for hnsw 
//    //4  for lc ← L … 1 
//    //5     W ← SEARCH-LAYER(q, ep, ef= 1, lc)
//    //6     ep ← get nearest element from W to q 
//    //7  W ← SEARCH-LAYER(q, ep, ef, lc = 0)
//    //8 return K nearest elements from W to q

//}

