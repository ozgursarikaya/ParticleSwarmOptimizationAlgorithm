using ParticleSwarmOptimizationAlgorithm;

Random random = new Random();
double minX = -10.0;
double maxX = 10.0;
int dimension = 2;
int swarmSize = 30;
int maxIterations = 100;

Bird[] swarm = new Bird[swarmSize];

for (int i = 0; i < swarmSize; i++)
{
    swarm[i] = new Bird(dimension, minX, maxX, random);
}

double[] globalBestPosition = new double[dimension];
double globalBestFitness = double.MaxValue;

for (int iteration = 0; iteration < maxIterations; iteration++)
{
    foreach (Bird bird in swarm)
    {
        for (int i = 0; i < dimension; i++)
        {
            double r1 = random.NextDouble();
            double r2 = random.NextDouble();
            bird.Velocity[i] = bird.Velocity[i] * 0.5 +
                                r1 * 2.0 * (bird.BestPosition[i] - bird.Position[i]) +
                                r2 * 2.0 * (globalBestPosition[i] - bird.Position[i]);

            bird.Position[i] += bird.Velocity[i];

            if (bird.Position[i] < minX)
            {
                bird.Position[i] = minX;
            }
            else if (bird.Position[i] > maxX)
            {
                bird.Position[i] = maxX;
            }
        }

        bird.UpdateBestPosition();
        if (bird.BestFitness < globalBestFitness)
        {
            globalBestFitness = bird.BestFitness;
            Array.Copy(bird.BestPosition, globalBestPosition, dimension);
        }
    }

    Console.WriteLine($"Iteration: {iteration}, Best fitness: {globalBestFitness}");
}

Console.WriteLine("Global Best Position: [" + string.Join(", ", globalBestPosition) + "]");
Console.WriteLine("Global Best Fitness: " + globalBestFitness);
