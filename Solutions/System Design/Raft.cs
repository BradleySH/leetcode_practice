// Leader Election
using System.Security.Cryptography.X509Certificates;

namespace SystemDesign;

public enum NodeState
{
    Follower,
    Candidate,
    Leader
}

public class RaftNode
{
    public int Id { get; }
    public int CurrentTerm { get; private set; }
    public NodeState State { get; private set; }
    public int VotedFor { get; private set; }
    public List<RaftNode> Cluster { get; set; }

    private readonly Random random = new Random();

    public RaftNode(int id)
    {
        Id = id;
        State = NodeState.Follower;
    }

    public void Start()
    {
        Task.Run(() => RunElectionTimeout());
    }

    private void RunElectionTimeout()
    {
        while (true)
        {
            int timeout = random.Next(150, 300);
            Thread.Sleep(timeout);

            if (State == NodeState.Follower)
            {
                Console.WriteLine($"Node {Id} timeout, starting election");
                StartElection();
            }
        }
    }

    private void StartElection()
    {
        State = NodeState.Candidate;
        CurrentTerm++;
        VotedFor = Id;
        int votes = 1;
        Console.WriteLine($"Node {Id} is now a candidate for term {CurrentTerm}");

        foreach (var node in Cluster)
        {
            if (node.Id == this.Id)
            continue;

            bool voteGranted = node.RequestVote(candidateId: this.Id, candidateTerm: CurrentTerm);
            if (voteGranted)
            votes++;
        }

        if (votes > Cluster.Count / 2)
        {
            Console.WriteLine($"Node {Id} won election for term {CurrentTerm}");
            State = NodeState.Leader;
            Task.Run(() => RunLeader());
        }
        else
        {
            Console.WriteLine($"Node {Id} lost election for term {CurrentTerm}");
            State = NodeState.Follower;
        }
    }

    public bool RequestVote(int candidateId, int candidateTerm)
    {
        if (candidateTerm > CurrentTerm)
        {
            CurrentTerm = candidateTerm;
            VotedFor = candidateId;
            State = NodeState.Follower;
            Console.WriteLine($"Node {Id} granted vote to {candidateId} for term {candidateTerm}");
            return true;
        }
        Console.WriteLine($"Node {Id} denied vote to {candidateId} for term {candidateTerm}");
        return false;
    }

    private void RunLeader()
    {
        while (State == NodeState.Leader)
        {
            Console.WriteLine($"Node {Id} is the leader, Sending Heartbeats");
            foreach (var node in Cluster)
            {
                if (node.Id == this.Id)
                continue;

                node.ReceiveHeartbeat(leaderId: this.Id, leaderTerm: CurrentTerm);
            }
            Thread.Sleep(100);
        }
    }

    public void ReceiveHeartbeat(int leaderId, int leaderTerm)
    {
        if (leaderTerm >= CurrentTerm)
        {
            CurrentTerm = leaderTerm;
            State = NodeState.Follower;
            Console.WriteLine($"Node {Id}: Received heartbeat from leader {leaderId} for term {leaderTerm}");
        }
    }
}