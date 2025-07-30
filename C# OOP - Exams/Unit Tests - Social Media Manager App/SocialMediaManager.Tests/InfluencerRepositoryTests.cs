using NUnit.Framework.Internal;

namespace SocialMediaManager.Tests
{
    public class InfluencerRepositoryTests
    {
        private InfluencerRepository influencerRepository;
        private Influencer defaultInfluencer;
        private string defaultInfluencerUsername;

        [SetUp]
        public void Setup()
        {
            this.influencerRepository = new InfluencerRepository();
            this.defaultInfluencer = new("Viral Vibes", 1000);
            this.defaultInfluencerUsername = "Digital Orbit";
        }

        [Test]
        public void InfluencerRepostitoryConstructor_ShouldSetEmptyList()
        {
            Assert.IsEmpty(this.influencerRepository.Influencers);
        }

        [Test]
        public void RegisterInfluencer_ShouldThrowArgumentNullException_WhenArgumentIsNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(
            () => this.influencerRepository.RegisterInfluencer(null));

            Assert.That(ex.Message, Does.Contain("Influencer is null"));
            Assert.That(ex.ParamName, Is.EqualTo("influencer"));
        }

        [Test]
        public void RegisterInfluencer_ShouldThrowInvalidOperationException_WhenUsernameExists()
        {
            this.influencerRepository.RegisterInfluencer(this.defaultInfluencer);

            var ex = Assert.Throws<InvalidOperationException>
                (() => this.influencerRepository
                .RegisterInfluencer(new Influencer("Viral Vibes", 5000)));

            Assert.That(ex.Message, Is.EqualTo($"Influencer with username " +
                $"{this.defaultInfluencer.Username} already exists"));
        }

        [Test]

        public void RegisterInfluencer_ShouldAddAnInfluencerCorrectly()
        {
            Assert.That(this.influencerRepository.Influencers.Count,
                Is.EqualTo(0));

            string resultMessage = this.influencerRepository.RegisterInfluencer(this.defaultInfluencer);

            Assert.That(this.influencerRepository.Influencers.Count, Is.EqualTo(1));

            var registeredInfluencer = this.influencerRepository.Influencers.First();
            Assert.That(registeredInfluencer.Username,
                Is.EqualTo(this.defaultInfluencer.Username));
            Assert.That(registeredInfluencer.Followers,
                Is.EqualTo(this.defaultInfluencer.Followers));

            var expectedMessage = $"Successfully added influencer " +
                $"{this.defaultInfluencer.Username} with {this.defaultInfluencer.Followers}";
            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        public void RemoveInfluencer_ShouldThrowArgumentNullException_WhenUsernameIsNullOrWhiteSpace()
        {
            ArgumentNullException resultMessage = Assert.Throws<ArgumentNullException>
                (() => this.influencerRepository.RemoveInfluencer(null));

            string expectedMessage = "Username cannot be null";
            Assert.That(resultMessage.Message, Does.Contain(expectedMessage));
            Assert.That(resultMessage.ParamName, Is.EqualTo("username"));
        }

        [Test]
        public void RemoveInfluencer_ShouldRemoveAnInfluencerCorrectly()
        {
            this.influencerRepository.RemoveInfluencer(this.defaultInfluencerUsername);
            Assert.That(!this.influencerRepository.Influencers.Contains(this.defaultInfluencer));
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnCorrectTrueResult()
        {
            this.influencerRepository.RegisterInfluencer(this.defaultInfluencer);
            int initialCount = this.influencerRepository.Influencers.Count;
            bool result = this.influencerRepository.RemoveInfluencer(this.defaultInfluencer.Username);
            int finalCount = this.influencerRepository.Influencers.Count;
            Assert.That(result, Is.True);
            Assert.That(finalCount, Is.EqualTo(initialCount - 1));
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnCorrectFalseResult()
        {
            int initialCountSecondCheck = this.influencerRepository.Influencers.Count;
            bool resultSecondCheck = this.influencerRepository.RemoveInfluencer(this.defaultInfluencer.Username);
            int finalCountSecondCheck = this.influencerRepository.Influencers.Count;
            Assert.That(resultSecondCheck, Is.False);
            Assert.That(finalCountSecondCheck, Is.EqualTo(initialCountSecondCheck));
        }

        [Test]

        public void GetInfluencerWithMostFollowers_ShouldCorrectlyReturnAnInfluencer_WithMostFollowers()
        {
            this.influencerRepository.RegisterInfluencer(this.defaultInfluencer);
            this.influencerRepository.RegisterInfluencer(new Influencer("BuzzBeam", 2000));
            this.influencerRepository.RegisterInfluencer(new Influencer("CharmChic", 3000));
            this.influencerRepository.RegisterInfluencer(new Influencer("PixelPioneer", 3000));

            Influencer influencerResult = this.influencerRepository.GetInfluencerWithMostFollowers();
            var expectedResult = new Influencer("CharmChic", 3000);

            Assert.That(this.influencerRepository.Influencers.Count, Is.EqualTo(4));

            Assert.That(influencerResult.Username, Is.EqualTo(expectedResult.Username));
            Assert.That(influencerResult.Followers, Is.EqualTo(expectedResult.Followers));
        }

        [Test]

        public void GetInfluencer_ShouldCorrectlyReturnAnInfluencerByUsername()
        {
            this.influencerRepository.RegisterInfluencer(this.defaultInfluencer);
            this.influencerRepository.RegisterInfluencer(new Influencer("BuzzBeam", 2000));
            this.influencerRepository.RegisterInfluencer(new Influencer("CharmChic", 3000));
            this.influencerRepository.RegisterInfluencer(new Influencer("PixelPioneer", 3000));

            Influencer influencerResult = this.influencerRepository.GetInfluencer("CharmChic");

            var expectedResult = new Influencer("CharmChic", 3000);

            Assert.That(influencerResult.Username, Is.EqualTo("CharmChic"));
            Assert.That(influencerResult.Followers, Is.EqualTo(3000));
        }
    }
}