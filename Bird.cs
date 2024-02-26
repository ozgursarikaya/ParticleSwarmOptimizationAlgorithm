using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSwarmOptimizationAlgorithm
{
    public class Bird
    {
        public double[] Position { get; set; }
        public double[] Velocity { get; set; }
        public double[] BestPosition { get; set; }
        public double BestFitness { get; set; }

        public Bird(int dimension, double minX, double maxX, Random random)
        {
            Position = new double[dimension];
            Velocity = new double[dimension];
            BestPosition = new double[dimension];
            BestFitness = double.MaxValue;

            for (int i = 0; i < dimension; i++)
            {
                Position[i] = random.NextDouble() * (maxX - minX) + minX;
                Velocity[i] = random.NextDouble() * (maxX - minX) - (maxX - minX) / 2;
            }

            Array.Copy(Position, BestPosition, dimension);
            BestFitness = CalculateFitness(Position);
        }

        public double CalculateFitness(double[] position)
        {
            return position[0] * position[0] + position[1] * position[1]; // x^2 + y^2
        }

        public void UpdateBestPosition()
        {
            double currentFitness = CalculateFitness(Position);
            if (currentFitness < BestFitness)
            {
                BestFitness = currentFitness;
                Array.Copy(Position, BestPosition, Position.Length);
            }
        }
    }
}
