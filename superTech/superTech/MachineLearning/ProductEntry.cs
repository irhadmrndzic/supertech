
using Microsoft.ML.Data;

namespace superTech.MachineLearning
{
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }
    public class ProductEntry
    {
        [KeyType(count: 100)]
        public uint ProductID { get; set; }

        [KeyType(count: 100)]
        public uint CoPurchaseProductID { get; set; }
        public float Label { get; set; }

    }
}
