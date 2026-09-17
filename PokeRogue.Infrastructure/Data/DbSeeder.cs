using PokeRogue.Application.Services;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;

namespace PokeRogue.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(PokeRogueDbContext context)
        {
            SeedAttackLines(context);
            SeedPokemonSpecies(context);
            SeedItems(context);
            SeedTrainerTypes(context);
            SeedMap(context);
            SeedCatchZones(context);

            context.SaveChanges();
        }

        private static void SeedAttackLines(PokeRogueDbContext context)
        {
            if (context.AttackLines.Any())
            {
                return;
            }

            var attackLines = new List<AttackLine>
            {
                new AttackLine
                {
                    Id = 1,
                    Stage1Name = "Vine Whip",
                    Stage1Power = 40,
                    Stage2Name = "Razor Leaf",
                    Stage2Power = 70,
                    Stage3Name = "Solar Beam",
                    Stage3Power = 100,
                    Type = PokemonType.Grass,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 2,
                    Stage1Name = "Ember",
                    Stage1Power = 40,
                    Stage2Name = "Flamethrower",
                    Stage2Power = 70,
                    Stage3Name = "Fire Blast",
                    Stage3Power = 100,
                    Type = PokemonType.Fire,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 3,
                    Stage1Name = "Bubble",
                    Stage1Power = 40,
                    Stage2Name = "Bubble Beam",
                    Stage2Power = 70,
                    Stage3Name = "Surf",
                    Stage3Power = 100,
                    Type = PokemonType.Water,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 4,
                    Stage1Name = "Thunder Shock",
                    Stage1Power = 40,
                    Stage2Name = "Thunderbolt",
                    Stage2Power = 70,
                    Stage3Name = "Thunder",
                    Stage3Power = 100,
                    Type = PokemonType.Electric,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 5,
                    Stage1Name = "Tackle",
                    Stage1Power = 40,
                    Stage2Name = "Quick Attack",
                    Stage2Power = 70,
                    Stage3Name = "Take Down",
                    Stage3Power = 100,
                    Type = PokemonType.Normal,
                    Category = AttackCategory.Physical
                },

                new AttackLine
                {
                    Id = 6,
                    Stage1Name = "Gust",
                    Stage1Power = 40,
                    Stage2Name = "Wing Attack",
                    Stage2Power = 70,
                    Stage3Name = "Aerial Ace",
                    Stage3Power = 100,
                    Type = PokemonType.Flying,
                    Category = AttackCategory.Physical
                },

                new AttackLine
                {
                    Id = 7,
                    Stage1Name = "Bug Bite",
                    Stage1Power = 40,
                    Stage2Name = "Twineedle",
                    Stage2Power = 70,
                    Stage3Name = "Pin Missile",
                    Stage3Power = 100,
                    Type = PokemonType.Bug,
                    Category = AttackCategory.Physical
                },

                new AttackLine
                {
                    Id = 8,
                    Stage1Name = "Poison Sting",
                    Stage1Power = 40,
                    Stage2Name = "Acid",
                    Stage2Power = 70,
                    Stage3Name = "Sludge Bomb",
                    Stage3Power = 100,
                    Type = PokemonType.Poison,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 9,
                    Stage1Name = "Mud-Slap",
                    Stage1Power = 40,
                    Stage2Name = "Dig",
                    Stage2Power = 70,
                    Stage3Name = "Earthquake",
                    Stage3Power = 100,
                    Type = PokemonType.Ground,
                    Category = AttackCategory.Physical
                },
                new AttackLine
                {
                    Id = 10,
                    Stage1Name = "Karate Chop",
                    Stage1Power = 40,
                    Stage2Name = "Brick Break",
                    Stage2Power = 70,
                    Stage3Name = "Cross Chop",
                    Stage3Power = 100,
                    Type = PokemonType.Fighting,
                    Category = AttackCategory.Physical
                },

                new AttackLine
                {
                    Id = 11,
                    Stage1Name = "Confusion",
                    Stage1Power = 40,
                    Stage2Name = "Psybeam",
                    Stage2Power = 70,
                    Stage3Name = "Psychic",
                    Stage3Power = 100,
                    Type = PokemonType.Psychic,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 12,
                    Stage1Name = "Rock Throw",
                    Stage1Power = 40,
                    Stage2Name = "Rock Slide",
                    Stage2Power = 70,
                    Stage3Name = "Stone Edge",
                    Stage3Power = 100,
                    Type = PokemonType.Rock,
                    Category = AttackCategory.Physical
                },
                new AttackLine
                {
                    Id = 13,
                    Stage1Name = "Astonish",
                    Stage1Power = 40,
                    Stage2Name = "Hex",
                    Stage2Power = 70,
                    Stage3Name = "Shadow Ball",
                    Stage3Power = 100,
                    Type = PokemonType.Ghost,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 14,
                    Stage1Name = "Ice Shard",
                    Stage1Power = 40,
                    Stage2Name = "Ice Beam",
                    Stage2Power = 70,
                    Stage3Name = "Blizzard",
                    Stage3Power = 100,
                    Type = PokemonType.Ice,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 15,
                    Stage1Name = "Dragon Breath",
                    Stage1Power = 40,
                    Stage2Name = "Dragon Pulse",
                    Stage2Power = 70,
                    Stage3Name = "Draco Meteor",
                    Stage3Power = 100,
                    Type = PokemonType.Dragon,
                    Category = AttackCategory.Special
                },

                new AttackLine
                {
                    Id = 16,
                    Stage1Name = "Bite",
                    Stage1Power = 40,
                    Stage2Name = "Crunch",
                    Stage2Power = 70,
                    Stage3Name = "Dark Pulse",
                    Stage3Power = 100,
                    Type = PokemonType.Dark,
                    Category = AttackCategory.Physical
                },

                new AttackLine
                {
                    Id = 17,
                    Stage1Name = "Metal Claw",
                    Stage1Power = 40,
                    Stage2Name = "Iron Head",
                    Stage2Power = 70,
                    Stage3Name = "Meteor Mash",
                    Stage3Power = 100,
                    Type = PokemonType.Steel,
                    Category = AttackCategory.Physical
                },
                new AttackLine
                {
                    Id = 18,
                    Stage1Name = "Fairy Wind",
                    Stage1Power = 40,
                    Stage2Name = "Draining Kiss",
                    Stage2Power = 70,
                    Stage3Name = "Moonblast",
                    Stage3Power = 100,
                    Type = PokemonType.Fairy,
                    Category = AttackCategory.Special
                }
            };

            context.AttackLines.AddRange(attackLines);
        }

        private static void SeedPokemonSpecies(PokeRogueDbContext context)
        {
            if (context.PokemonSpecies.Any())
            {
                return;
            }

            var pokemonSpecies = new List<PokemonSpecies>
            {
                new PokemonSpecies
                {
                    Id = 1,
                    Name = "Bulbasaur",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 45,
                    BaseAttack = 49,
                    BaseDefense = 49,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 45,
                    AttackLineId = 1,
                    IsStarter = true,
                    EvolutionStage = 1,
                    EvolveAtLevel = 16,
                    EvolvesIntoSpeciesId = 2
                },

                new PokemonSpecies
                {
                    Id = 2,
                    Name = "Ivysaur",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 60,
                    BaseAttack = 62,
                    BaseDefense = 63,
                    BaseSpecialAttack = 80,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 60,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 3
                },

                new PokemonSpecies
                {
                    Id = 3,
                    Name = "Venusaur",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 80,
                    BaseAttack = 82,
                    BaseDefense = 83,
                    BaseSpecialAttack = 100,
                    BaseSpecialDefense = 100,
                    BaseSpeed = 80,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 4,
                    Name = "Charmander",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 39,
                    BaseAttack = 52,
                    BaseDefense = 43,
                    BaseSpecialAttack = 60,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 65,
                    AttackLineId = 2,
                    IsStarter = true,
                    EvolutionStage = 1,
                    EvolveAtLevel = 16,
                    EvolvesIntoSpeciesId = 5
                },

                new PokemonSpecies
                {
                    Id = 5,
                    Name = "Charmeleon",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 58,
                    BaseAttack = 64,
                    BaseDefense = 58,
                    BaseSpecialAttack = 80,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 80,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 36,
                    EvolvesIntoSpeciesId = 6
                },

                new PokemonSpecies
                {
                    Id = 6,
                    Name = "Charizard",
                    Type1 = PokemonType.Fire,
                    Type2 = PokemonType.Flying,
                    BaseHp = 78,
                    BaseAttack = 84,
                    BaseDefense = 78,
                    BaseSpecialAttack = 109,
                    BaseSpecialDefense = 85,
                    BaseSpeed = 100,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 7,
                    Name = "Squirtle",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 44,
                    BaseAttack = 48,
                    BaseDefense = 65,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 64,
                    BaseSpeed = 43,
                    AttackLineId = 3,
                    IsStarter = true,
                    EvolutionStage = 1,
                    EvolveAtLevel = 16,
                    EvolvesIntoSpeciesId = 8
                },

                new PokemonSpecies
                {
                    Id = 8,
                    Name = "Wartortle",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 59,
                    BaseAttack = 63,
                    BaseDefense = 80,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 58,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 36,
                    EvolvesIntoSpeciesId = 9
                },

                new PokemonSpecies
                {
                    Id = 9,
                    Name = "Blastoise",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 79,
                    BaseAttack = 83,
                    BaseDefense = 100,
                    BaseSpecialAttack = 85,
                    BaseSpecialDefense = 105,
                    BaseSpeed = 78,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 10,
                    Name = "Caterpie",
                    Type1 = PokemonType.Bug,
                    Type2 = null,
                    BaseHp = 45,
                    BaseAttack = 30,
                    BaseDefense = 35,
                    BaseSpecialAttack = 20,
                    BaseSpecialDefense = 20,
                    BaseSpeed = 45,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 7,
                    EvolvesIntoSpeciesId = 11
                },
                new PokemonSpecies
                {
                    Id = 11,
                    Name = "Metapod",
                    Type1 = PokemonType.Bug,
                    Type2 = null,
                    BaseHp = 50,
                    BaseAttack = 20,
                    BaseDefense = 55,
                    BaseSpecialAttack = 25,
                    BaseSpecialDefense = 25,
                    BaseSpeed = 30,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 10,
                    EvolvesIntoSpeciesId = 12
                },

                new PokemonSpecies
                {
                    Id = 12,
                    Name = "Butterfree",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Flying,
                    BaseHp = 60,
                    BaseAttack = 45,
                    BaseDefense = 50,
                    BaseSpecialAttack = 90,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 70,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 13,
                    Name = "Weedle",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Poison,
                    BaseHp = 40,
                    BaseAttack = 35,
                    BaseDefense = 30,
                    BaseSpecialAttack = 20,
                    BaseSpecialDefense = 20,
                    BaseSpeed = 50,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 7,
                    EvolvesIntoSpeciesId = 14
                },

                new PokemonSpecies
                {
                    Id = 14,
                    Name = "Kakuna",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Poison,
                    BaseHp = 45,
                    BaseAttack = 25,
                    BaseDefense = 50,
                    BaseSpecialAttack = 25,
                    BaseSpecialDefense = 25,
                    BaseSpeed = 35,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 10,
                    EvolvesIntoSpeciesId = 15
                },

                new PokemonSpecies
                {
                    Id = 15,
                    Name = "Beedrill",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Poison,
                    BaseHp = 65,
                    BaseAttack = 90,
                    BaseDefense = 40,
                    BaseSpecialAttack = 45,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 75,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 16,
                    Name = "Pidgey",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 40,
                    BaseAttack = 45,
                    BaseDefense = 40,
                    BaseSpecialAttack = 35,
                    BaseSpecialDefense = 35,
                    BaseSpeed = 56,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 18,
                    EvolvesIntoSpeciesId = 17
                },

                new PokemonSpecies
                {
                    Id = 17,
                    Name = "Pidgeotto",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 63,
                    BaseAttack = 60,
                    BaseDefense = 55,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 71,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 36,
                    EvolvesIntoSpeciesId = 18
                },

                new PokemonSpecies
                {
                    Id = 18,
                    Name = "Pidgeot",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 83,
                    BaseAttack = 80,
                    BaseDefense = 75,
                    BaseSpecialAttack = 70,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 101,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 19,
                    Name = "Rattata",
                    Type1 = PokemonType.Normal,
                    Type2 = null,
                    BaseHp = 30,
                    BaseAttack = 56,
                    BaseDefense = 35,
                    BaseSpecialAttack = 25,
                    BaseSpecialDefense = 35,
                    BaseSpeed = 72,
                    AttackLineId = 5,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 20,
                    EvolvesIntoSpeciesId = 20
                },

                new PokemonSpecies
                {
                    Id = 20,
                    Name = "Raticate",
                    Type1 = PokemonType.Normal,
                    Type2 = null,
                    BaseHp = 55,
                    BaseAttack = 81,
                    BaseDefense = 60,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 97,
                    AttackLineId = 5,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },
                new PokemonSpecies
                {
                    Id = 21,
                    Name = "Spearow",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 40,
                    BaseAttack = 60,
                    BaseDefense = 30,
                    BaseSpecialAttack = 31,
                    BaseSpecialDefense = 31,
                    BaseSpeed = 70,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 20,
                    EvolvesIntoSpeciesId = 22
                },

                new PokemonSpecies
                {
                    Id = 22,
                    Name = "Fearow",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 65,
                    BaseAttack = 90,
                    BaseDefense = 65,
                    BaseSpecialAttack = 61,
                    BaseSpecialDefense = 61,
                    BaseSpeed = 100,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 23,
                    Name = "Ekans",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 35,
                    BaseAttack = 60,
                    BaseDefense = 44,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 54,
                    BaseSpeed = 55,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 22,
                    EvolvesIntoSpeciesId = 24
                },

                new PokemonSpecies
                {
                    Id = 24,
                    Name = "Arbok",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 60,
                    BaseAttack = 95,
                    BaseDefense = 69,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 79,
                    BaseSpeed = 80,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 25,
                    Name = "Pikachu",
                    Type1 = PokemonType.Electric,
                    Type2 = null,
                    BaseHp = 35,
                    BaseAttack = 55,
                    BaseDefense = 40,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 90,
                    AttackLineId = 4,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 30,
                    EvolvesIntoSpeciesId = 26
                },

                new PokemonSpecies
                {
                    Id = 26,
                    Name = "Raichu",
                    Type1 = PokemonType.Electric,
                    Type2 = null,
                    BaseHp = 60,
                    BaseAttack = 90,
                    BaseDefense = 55,
                    BaseSpecialAttack = 90,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 110,
                    AttackLineId = 4,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 27,
                    Name = "Sandshrew",
                    Type1 = PokemonType.Ground,
                    Type2 = null,
                    BaseHp = 50,
                    BaseAttack = 75,
                    BaseDefense = 85,
                    BaseSpecialAttack = 20,
                    BaseSpecialDefense = 30,
                    BaseSpeed = 40,
                    AttackLineId = 9,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 22,
                    EvolvesIntoSpeciesId = 28
                },

                new PokemonSpecies
                {
                    Id = 28,
                    Name = "Sandslash",
                    Type1 = PokemonType.Ground,
                    Type2 = null,
                    BaseHp = 75,
                    BaseAttack = 100,
                    BaseDefense = 110,
                    BaseSpecialAttack = 45,
                    BaseSpecialDefense = 55,
                    BaseSpeed = 65,
                    AttackLineId = 9,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 29,
                    Name = "Nidoran♀",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 55,
                    BaseAttack = 47,
                    BaseDefense = 52,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 40,
                    BaseSpeed = 41,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 16,
                    EvolvesIntoSpeciesId = 30
                },

                new PokemonSpecies
                {
                    Id = 30,
                    Name = "Nidorina",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 70,
                    BaseAttack = 62,
                    BaseDefense = 67,
                    BaseSpecialAttack = 55,
                    BaseSpecialDefense = 55,
                    BaseSpeed = 56,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 31
                },
                new PokemonSpecies
                {
                    Id = 31,
                    Name = "Nidoqueen",
                    Type1 = PokemonType.Poison,
                    Type2 = PokemonType.Ground,
                    BaseHp = 90,
                    BaseAttack = 92,
                    BaseDefense = 87,
                    BaseSpecialAttack = 75,
                    BaseSpecialDefense = 85,
                    BaseSpeed = 76,
                    AttackLineId = 9,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 32,
                    Name = "Nidoran♂",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 46,
                    BaseAttack = 57,
                    BaseDefense = 40,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 40,
                    BaseSpeed = 50,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 16,
                    EvolvesIntoSpeciesId = 33
                },

                new PokemonSpecies
                {
                    Id = 33,
                    Name = "Nidorino",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 61,
                    BaseAttack = 72,
                    BaseDefense = 57,
                    BaseSpecialAttack = 55,
                    BaseSpecialDefense = 55,
                    BaseSpeed = 65,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 34
                },

                new PokemonSpecies
                {
                    Id = 34,
                    Name = "Nidoking",
                    Type1 = PokemonType.Poison,
                    Type2 = PokemonType.Ground,
                    BaseHp = 81,
                    BaseAttack = 102,
                    BaseDefense = 77,
                    BaseSpecialAttack = 85,
                    BaseSpecialDefense = 75,
                    BaseSpeed = 85,
                    AttackLineId = 9,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 35,
                    Name = "Clefairy",
                    Type1 = PokemonType.Fairy,
                    Type2 = null,
                    BaseHp = 70,
                    BaseAttack = 45,
                    BaseDefense = 48,
                    BaseSpecialAttack = 60,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 35,
                    AttackLineId = 5,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 30,
                    EvolvesIntoSpeciesId = 36
                },

                new PokemonSpecies
                {
                    Id = 36,
                    Name = "Clefable",
                    Type1 = PokemonType.Fairy,
                    Type2 = null,
                    BaseHp = 95,
                    BaseAttack = 70,
                    BaseDefense = 73,
                    BaseSpecialAttack = 95,
                    BaseSpecialDefense = 90,
                    BaseSpeed = 60,
                    AttackLineId = 18,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 37,
                    Name = "Vulpix",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 38,
                    BaseAttack = 41,
                    BaseDefense = 40,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 65,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 30,
                    EvolvesIntoSpeciesId = 38
                },

                new PokemonSpecies
                {
                    Id = 38,
                    Name = "Ninetales",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 73,
                    BaseAttack = 76,
                    BaseDefense = 75,
                    BaseSpecialAttack = 81,
                    BaseSpecialDefense = 100,
                    BaseSpeed = 100,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 39,
                    Name = "Jigglypuff",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Fairy,
                    BaseHp = 115,
                    BaseAttack = 45,
                    BaseDefense = 20,
                    BaseSpecialAttack = 45,
                    BaseSpecialDefense = 25,
                    BaseSpeed = 20,
                    AttackLineId = 5,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 30,
                    EvolvesIntoSpeciesId = 40
                },

                new PokemonSpecies
                {
                    Id = 40,
                    Name = "Wigglytuff",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Fairy,
                    BaseHp = 140,
                    BaseAttack = 70,
                    BaseDefense = 45,
                    BaseSpecialAttack = 85,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 45,
                    AttackLineId = 18,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },
                new PokemonSpecies
                {
                    Id = 41,
                    Name = "Zubat",
                    Type1 = PokemonType.Poison,
                    Type2 = PokemonType.Flying,
                    BaseHp = 40,
                    BaseAttack = 45,
                    BaseDefense = 35,
                    BaseSpecialAttack = 30,
                    BaseSpecialDefense = 40,
                    BaseSpeed = 55,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 22,
                    EvolvesIntoSpeciesId = 42
                },

                new PokemonSpecies
                {
                    Id = 42,
                    Name = "Golbat",
                    Type1 = PokemonType.Poison,
                    Type2 = PokemonType.Flying,
                    BaseHp = 75,
                    BaseAttack = 80,
                    BaseDefense = 70,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 75,
                    BaseSpeed = 90,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 43,
                    Name = "Oddish",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 45,
                    BaseAttack = 50,
                    BaseDefense = 55,
                    BaseSpecialAttack = 75,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 30,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 21,
                    EvolvesIntoSpeciesId = 44
                },

                new PokemonSpecies
                {
                    Id = 44,
                    Name = "Gloom",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 60,
                    BaseAttack = 65,
                    BaseDefense = 70,
                    BaseSpecialAttack = 85,
                    BaseSpecialDefense = 75,
                    BaseSpeed = 40,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 45
                },

                new PokemonSpecies
                {
                    Id = 45,
                    Name = "Vileplume",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 75,
                    BaseAttack = 80,
                    BaseDefense = 85,
                    BaseSpecialAttack = 110,
                    BaseSpecialDefense = 90,
                    BaseSpeed = 50,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 46,
                    Name = "Paras",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Grass,
                    BaseHp = 35,
                    BaseAttack = 70,
                    BaseDefense = 55,
                    BaseSpecialAttack = 45,
                    BaseSpecialDefense = 55,
                    BaseSpeed = 25,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 24,
                    EvolvesIntoSpeciesId = 47
                },

                new PokemonSpecies
                {
                    Id = 47,
                    Name = "Parasect",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Grass,
                    BaseHp = 60,
                    BaseAttack = 95,
                    BaseDefense = 80,
                    BaseSpecialAttack = 60,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 30,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 48,
                    Name = "Venonat",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Poison,
                    BaseHp = 60,
                    BaseAttack = 55,
                    BaseDefense = 50,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 55,
                    BaseSpeed = 45,
                    AttackLineId = 7,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 31,
                    EvolvesIntoSpeciesId = 49
                },

                new PokemonSpecies
                {
                    Id = 49,
                    Name = "Venomoth",
                    Type1 = PokemonType.Bug,
                    Type2 = PokemonType.Poison,
                    BaseHp = 70,
                    BaseAttack = 65,
                    BaseDefense = 60,
                    BaseSpecialAttack = 90,
                    BaseSpecialDefense = 75,
                    BaseSpeed = 90,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 50,
                    Name = "Diglett",
                    Type1 = PokemonType.Ground,
                    Type2 = null,
                    BaseHp = 10,
                    BaseAttack = 55,
                    BaseDefense = 25,
                    BaseSpecialAttack = 35,
                    BaseSpecialDefense = 45,
                    BaseSpeed = 95,
                    AttackLineId = 9,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 26,
                    EvolvesIntoSpeciesId = 51
                },
                new PokemonSpecies
                {
                    Id = 51,
                    Name = "Dugtrio",
                    Type1 = PokemonType.Ground,
                    Type2 = null,
                    BaseHp = 35,
                    BaseAttack = 100,
                    BaseDefense = 50,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 120,
                    AttackLineId = 9,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 52,
                    Name = "Meowth",
                    Type1 = PokemonType.Normal,
                    Type2 = null,
                    BaseHp = 40,
                    BaseAttack = 45,
                    BaseDefense = 35,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 40,
                    BaseSpeed = 90,
                    AttackLineId = 5,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 28,
                    EvolvesIntoSpeciesId = 53
                },

                new PokemonSpecies
                {
                    Id = 53,
                    Name = "Persian",
                    Type1 = PokemonType.Normal,
                    Type2 = null,
                    BaseHp = 65,
                    BaseAttack = 70,
                    BaseDefense = 60,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 115,
                    AttackLineId = 5,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 54,
                    Name = "Psyduck",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 50,
                    BaseAttack = 52,
                    BaseDefense = 48,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 55,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 33,
                    EvolvesIntoSpeciesId = 55
                },

                new PokemonSpecies
                {
                    Id = 55,
                    Name = "Golduck",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 80,
                    BaseAttack = 82,
                    BaseDefense = 78,
                    BaseSpecialAttack = 95,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 85,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 56,
                    Name = "Mankey",
                    Type1 = PokemonType.Fighting,
                    Type2 = null,
                    BaseHp = 40,
                    BaseAttack = 80,
                    BaseDefense = 35,
                    BaseSpecialAttack = 35,
                    BaseSpecialDefense = 45,
                    BaseSpeed = 70,
                    AttackLineId = 10,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 28,
                    EvolvesIntoSpeciesId = 57
                },

                new PokemonSpecies
                {
                    Id = 57,
                    Name = "Primeape",
                    Type1 = PokemonType.Fighting,
                    Type2 = null,
                    BaseHp = 65,
                    BaseAttack = 105,
                    BaseDefense = 60,
                    BaseSpecialAttack = 60,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 95,
                    AttackLineId = 10,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 58,
                    Name = "Growlithe",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 55,
                    BaseAttack = 70,
                    BaseDefense = 45,
                    BaseSpecialAttack = 70,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 60,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 59
                },

                new PokemonSpecies
                {
                    Id = 59,
                    Name = "Arcanine",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 90,
                    BaseAttack = 110,
                    BaseDefense = 80,
                    BaseSpecialAttack = 100,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 95,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },
                new PokemonSpecies
                {
                    Id = 60,
                    Name = "Poliwag",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 40,
                    BaseAttack = 50,
                    BaseDefense = 40,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 40,
                    BaseSpeed = 90,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 25,
                    EvolvesIntoSpeciesId = 61
                },
                new PokemonSpecies
                {
                    Id = 61,
                    Name = "Poliwhirl",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 65,
                    BaseAttack = 65,
                    BaseDefense = 65,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 90,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 62
                },

                new PokemonSpecies
                {
                    Id = 62,
                    Name = "Poliwrath",
                    Type1 = PokemonType.Water,
                    Type2 = PokemonType.Fighting,
                    BaseHp = 90,
                    BaseAttack = 95,
                    BaseDefense = 95,
                    BaseSpecialAttack = 70,
                    BaseSpecialDefense = 90,
                    BaseSpeed = 70,
                    AttackLineId = 10,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 63,
                    Name = "Abra",
                    Type1 = PokemonType.Psychic,
                    Type2 = null,
                    BaseHp = 25,
                    BaseAttack = 20,
                    BaseDefense = 15,
                    BaseSpecialAttack = 105,
                    BaseSpecialDefense = 55,
                    BaseSpeed = 90,
                    AttackLineId = 11,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 16,
                    EvolvesIntoSpeciesId = 64
                },

                new PokemonSpecies
                {
                    Id = 64,
                    Name = "Kadabra",
                    Type1 = PokemonType.Psychic,
                    Type2 = null,
                    BaseHp = 40,
                    BaseAttack = 35,
                    BaseDefense = 30,
                    BaseSpecialAttack = 120,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 105,
                    AttackLineId = 11,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 36,
                    EvolvesIntoSpeciesId = 65
                },

                new PokemonSpecies
                {
                    Id = 65,
                    Name = "Alakazam",
                    Type1 = PokemonType.Psychic,
                    Type2 = null,
                    BaseHp = 55,
                    BaseAttack = 50,
                    BaseDefense = 45,
                    BaseSpecialAttack = 135,
                    BaseSpecialDefense = 95,
                    BaseSpeed = 120,
                    AttackLineId = 11,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 66,
                    Name = "Machop",
                    Type1 = PokemonType.Fighting,
                    Type2 = null,
                    BaseHp = 70,
                    BaseAttack = 80,
                    BaseDefense = 50,
                    BaseSpecialAttack = 35,
                    BaseSpecialDefense = 35,
                    BaseSpeed = 35,
                    AttackLineId = 10,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 28,
                    EvolvesIntoSpeciesId = 67
                },

                new PokemonSpecies
                {
                    Id = 67,
                    Name = "Machoke",
                    Type1 = PokemonType.Fighting,
                    Type2 = null,
                    BaseHp = 80,
                    BaseAttack = 100,
                    BaseDefense = 70,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 60,
                    BaseSpeed = 45,
                    AttackLineId = 10,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 40,
                    EvolvesIntoSpeciesId = 68
                },

                new PokemonSpecies
                {
                    Id = 68,
                    Name = "Machamp",
                    Type1 = PokemonType.Fighting,
                    Type2 = null,
                    BaseHp = 90,
                    BaseAttack = 130,
                    BaseDefense = 80,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 85,
                    BaseSpeed = 55,
                    AttackLineId = 10,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 69,
                    Name = "Bellsprout",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 50,
                    BaseAttack = 75,
                    BaseDefense = 35,
                    BaseSpecialAttack = 70,
                    BaseSpecialDefense = 30,
                    BaseSpeed = 40,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 21,
                    EvolvesIntoSpeciesId = 70
                },

                new PokemonSpecies
                {
                    Id = 70,
                    Name = "Weepinbell",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 65,
                    BaseAttack = 90,
                    BaseDefense = 50,
                    BaseSpecialAttack = 85,
                    BaseSpecialDefense = 45,
                    BaseSpeed = 55,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 71
                },
                new PokemonSpecies
                {
                    Id = 71,
                    Name = "Victreebel",
                    Type1 = PokemonType.Grass,
                    Type2 = PokemonType.Poison,
                    BaseHp = 80,
                    BaseAttack = 105,
                    BaseDefense = 65,
                    BaseSpecialAttack = 100,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 70,
                    AttackLineId = 1,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 72,
                    Name = "Tentacool",
                    Type1 = PokemonType.Water,
                    Type2 = PokemonType.Poison,
                    BaseHp = 40,
                    BaseAttack = 40,
                    BaseDefense = 35,
                    BaseSpecialAttack = 50,
                    BaseSpecialDefense = 100,
                    BaseSpeed = 70,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 30,
                    EvolvesIntoSpeciesId = 73
                },

                new PokemonSpecies
                {
                    Id = 73,
                    Name = "Tentacruel",
                    Type1 = PokemonType.Water,
                    Type2 = PokemonType.Poison,
                    BaseHp = 80,
                    BaseAttack = 70,
                    BaseDefense = 65,
                    BaseSpecialAttack = 80,
                    BaseSpecialDefense = 120,
                    BaseSpeed = 100,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 74,
                    Name = "Geodude",
                    Type1 = PokemonType.Rock,
                    Type2 = PokemonType.Ground,
                    BaseHp = 40,
                    BaseAttack = 80,
                    BaseDefense = 100,
                    BaseSpecialAttack = 30,
                    BaseSpecialDefense = 30,
                    BaseSpeed = 20,
                    AttackLineId = 12,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 25,
                    EvolvesIntoSpeciesId = 75
                },

                new PokemonSpecies
                {
                    Id = 75,
                    Name = "Graveler",
                    Type1 = PokemonType.Rock,
                    Type2 = PokemonType.Ground,
                    BaseHp = 55,
                    BaseAttack = 95,
                    BaseDefense = 115,
                    BaseSpecialAttack = 45,
                    BaseSpecialDefense = 45,
                    BaseSpeed = 35,
                    AttackLineId = 12,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = 40,
                    EvolvesIntoSpeciesId = 76
                },

                new PokemonSpecies
                {
                    Id = 76,
                    Name = "Golem",
                    Type1 = PokemonType.Rock,
                    Type2 = PokemonType.Ground,
                    BaseHp = 80,
                    BaseAttack = 120,
                    BaseDefense = 130,
                    BaseSpecialAttack = 55,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 45,
                    AttackLineId = 12,
                    IsStarter = false,
                    EvolutionStage = 3,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 77,
                    Name = "Ponyta",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 50,
                    BaseAttack = 85,
                    BaseDefense = 55,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 65,
                    BaseSpeed = 90,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 40,
                    EvolvesIntoSpeciesId = 78
                },

                new PokemonSpecies
                {
                    Id = 78,
                    Name = "Rapidash",
                    Type1 = PokemonType.Fire,
                    Type2 = null,
                    BaseHp = 65,
                    BaseAttack = 100,
                    BaseDefense = 70,
                    BaseSpecialAttack = 80,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 105,
                    AttackLineId = 2,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 79,
                    Name = "Slowpoke",
                    Type1 = PokemonType.Water,
                    Type2 = PokemonType.Psychic,
                    BaseHp = 90,
                    BaseAttack = 65,
                    BaseDefense = 65,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 40,
                    BaseSpeed = 15,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 37,
                    EvolvesIntoSpeciesId = 80
                },

                new PokemonSpecies
                {
                    Id = 80,
                    Name = "Slowbro",
                    Type1 = PokemonType.Water,
                    Type2 = PokemonType.Psychic,
                    BaseHp = 95,
                    BaseAttack = 75,
                    BaseDefense = 110,
                    BaseSpecialAttack = 100,
                    BaseSpecialDefense = 80,
                    BaseSpeed = 30,
                    AttackLineId = 11,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },
                new PokemonSpecies
                {
                    Id = 81,
                    Name = "Magnemite",
                    Type1 = PokemonType.Electric,
                    Type2 = PokemonType.Steel,
                    BaseHp = 25,
                    BaseAttack = 35,
                    BaseDefense = 70,
                    BaseSpecialAttack = 95,
                    BaseSpecialDefense = 55,
                    BaseSpeed = 45,
                    AttackLineId = 4,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 30,
                    EvolvesIntoSpeciesId = 82
                },

                new PokemonSpecies
                {
                    Id = 82,
                    Name = "Magneton",
                    Type1 = PokemonType.Electric,
                    Type2 = PokemonType.Steel,
                    BaseHp = 50,
                    BaseAttack = 60,
                    BaseDefense = 95,
                    BaseSpecialAttack = 120,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 70,
                    AttackLineId = 4,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 83,
                    Name = "Farfetch'd",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 52,
                    BaseAttack = 90,
                    BaseDefense = 55,
                    BaseSpecialAttack = 58,
                    BaseSpecialDefense = 62,
                    BaseSpeed = 60,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 84,
                    Name = "Doduo",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 35,
                    BaseAttack = 85,
                    BaseDefense = 45,
                    BaseSpecialAttack = 35,
                    BaseSpecialDefense = 35,
                    BaseSpeed = 75,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 31,
                    EvolvesIntoSpeciesId = 85
                },

                new PokemonSpecies
                {
                    Id = 85,
                    Name = "Dodrio",
                    Type1 = PokemonType.Normal,
                    Type2 = PokemonType.Flying,
                    BaseHp = 60,
                    BaseAttack = 110,
                    BaseDefense = 70,
                    BaseSpecialAttack = 60,
                    BaseSpecialDefense = 60,
                    BaseSpeed = 110,
                    AttackLineId = 6,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 86,
                    Name = "Seel",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 65,
                    BaseAttack = 45,
                    BaseDefense = 55,
                    BaseSpecialAttack = 45,
                    BaseSpecialDefense = 70,
                    BaseSpeed = 45,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 34,
                    EvolvesIntoSpeciesId = 87
                },

                new PokemonSpecies
                {
                    Id = 87,
                    Name = "Dewgong",
                    Type1 = PokemonType.Water,
                    Type2 = PokemonType.Ice,
                    BaseHp = 90,
                    BaseAttack = 70,
                    BaseDefense = 80,
                    BaseSpecialAttack = 70,
                    BaseSpecialDefense = 95,
                    BaseSpeed = 70,
                    AttackLineId = 14,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 88,
                    Name = "Grimer",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 80,
                    BaseAttack = 80,
                    BaseDefense = 50,
                    BaseSpecialAttack = 40,
                    BaseSpecialDefense = 50,
                    BaseSpeed = 25,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 38,
                    EvolvesIntoSpeciesId = 89
                },

                new PokemonSpecies
                {
                    Id = 89,
                    Name = "Muk",
                    Type1 = PokemonType.Poison,
                    Type2 = null,
                    BaseHp = 105,
                    BaseAttack = 105,
                    BaseDefense = 75,
                    BaseSpecialAttack = 65,
                    BaseSpecialDefense = 100,
                    BaseSpeed = 50,
                    AttackLineId = 8,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },

                new PokemonSpecies
                {
                    Id = 90,
                    Name = "Shellder",
                    Type1 = PokemonType.Water,
                    Type2 = null,
                    BaseHp = 30,
                    BaseAttack = 65,
                    BaseDefense = 100,
                    BaseSpecialAttack = 45,
                    BaseSpecialDefense = 25,
                    BaseSpeed = 40,
                    AttackLineId = 3,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = 32,
                    EvolvesIntoSpeciesId = 91
                },

                new PokemonSpecies
                {
                    Id = 91,
                    Name = "Cloyster",
                    Type1 = PokemonType.Water,
                    Type2 = PokemonType.Ice,
                    BaseHp = 50,
                    BaseAttack = 95,
                    BaseDefense = 180,
                    BaseSpecialAttack = 85,
                    BaseSpecialDefense = 45,
                    BaseSpeed = 70,
                    AttackLineId = 14,
                    IsStarter = false,
                    EvolutionStage = 2,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },
                new PokemonSpecies
                {
                    Id = 95,
                    Name = "Onix",
                    Type1 = PokemonType.Rock,
                    Type2 = PokemonType.Ground,
                    BaseHp = 35,
                    BaseAttack = 45,
                    BaseDefense = 160,
                    BaseSpecialAttack = 30,
                    BaseSpecialDefense = 45,
                    BaseSpeed = 70,
                    AttackLineId = 12,
                    IsStarter = false,
                    EvolutionStage = 1,
                    EvolveAtLevel = null,
                    EvolvesIntoSpeciesId = null
                },
            };

            context.PokemonSpecies.AddRange(pokemonSpecies);
        }

        private static void SeedItems(PokeRogueDbContext context)
        {
            if (context.Items.Any())
            {
                return;
            }

            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Charcoal",
                    Description = "Boosts the power of Fire-type attacks by 40%.",
                    EffectType = ItemEffectType.TypeDamageBoost,
                    Trigger = ItemTrigger.Passive,
                    Target = ItemTarget.Self,
                    Value = 40,
                    TargetPokemonType = PokemonType.Fire,
                    IsConsumable = false
                },

                new Item
                {
                    Id = 2,
                    Name = "TM",
                    Description = "Upgrades a Pokémon's attack to the next stage.",
                    EffectType = ItemEffectType.AttackUpgrade,
                    Trigger = ItemTrigger.OnUse,
                    Target = ItemTarget.Self,
                    Value = 1,
                    TargetPokemonType = null,
                    IsConsumable = true
                },

                new Item
                {
                    Id = 3,
                    Name = "Rocky Helmet",
                    Description = "An attacker loses 12% of its maximum HP after attacking the holder.",
                    EffectType = ItemEffectType.RecoilDamage,
                    Trigger = ItemTrigger.OnAttacked,
                    Target = ItemTarget.Opponent,
                    Value = 12,
                    TargetPokemonType = null,
                    IsConsumable = false
                },

                new Item
                {
                    Id = 4,
                    Name = "Full Revive",
                    Description = "Restores a Pokémon to full HP, whether fainted or not.",
                    EffectType = ItemEffectType.Revive,
                    Trigger = ItemTrigger.OnUse,
                    Target = ItemTarget.Self,
                    Value = 100,
                    TargetPokemonType = null,
                    IsConsumable = true
                },

                new Item
                {
                    Id = 5,
                    Name = "Rare Candy",
                    Description = "Raises a Pokémon's level by 3.",
                    EffectType = ItemEffectType.LevelUp,
                    Trigger = ItemTrigger.OnUse,
                    Target = ItemTarget.Self,
                    Value = 3,
                    TargetPokemonType = null,
                    IsConsumable = true
                }
            };

            context.Items.AddRange(items);
        }

        private static void SeedTrainerTypes(PokeRogueDbContext context)
        {
            if (context.TrainerTypes.Any())
            {
                return;
            }

            var trainerTypes = new List<TrainerType>
            {
                new TrainerType
                {
                    Id = 1,
                    Name = "Bug Catcher",
                    Type1 = PokemonType.Bug,
                    Type2 = null
                },

                new TrainerType
                {
                    Id = 2,
                    Name = "Hiker",
                    Type1 = PokemonType.Rock,
                    Type2 = PokemonType.Ground
                },

                new TrainerType
                {
                    Id = 3,
                    Name = "Swimmer",
                    Type1 = PokemonType.Water,
                    Type2 = null
                },

                new TrainerType
                {
                    Id = 4,
                    Name = "Psychic",
                    Type1 = PokemonType.Psychic,
                    Type2 = null
                },

                new TrainerType
                {
                    Id = 5,
                    Name = "Black Belt",
                    Type1 = PokemonType.Fighting,
                    Type2 = null
                },

                new TrainerType
                {
                    Id = 6,
                    Name = "Bird Keeper",
                    Type1 = PokemonType.Flying,
                    Type2 = null
                },

                new TrainerType
                {
                    Id = 7,
                    Name = "Scientist",
                    Type1 = PokemonType.Electric,
                    Type2 = PokemonType.Poison
                },

                new TrainerType
                {
                    Id = 8,
                    Name = "Channeler",
                    Type1 = PokemonType.Ghost,
                    Type2 = PokemonType.Psychic
                }
            };

            context.TrainerTypes.AddRange(trainerTypes);
        }

        private static void SeedMap(
            PokeRogueDbContext context
        )
        {
            if (context.MapNodes.Any())
            {
                return;
            }

            var mapFactory =
                new CityMapFactory();

            for (int cityNumber = 1;
                 cityNumber <= 8;
                 cityNumber++)
            {
                MapLayout city =
                    mapFactory.CreateCityMap(
                        cityNumber
                    );

                context.MapNodes.AddRange(
                    city.Nodes
                );

                context.MapConnections.AddRange(
                    city.Connections
                );
            }
        }

        private static void SeedCatchZones(
            PokeRogueDbContext context
        )
        {
            if (context.CatchZones.Any())
            {
                return;
            }

            var catchZones = new List<CatchZone>
            {
                // =====================================================
                // CITY 1 - PEWTER CITY
                // Early-game Pokémon. Stage 1 only.
                // =====================================================

                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 10, // Caterpie
                    Weight = 20
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 13, // Weedle
                    Weight = 20
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 16, // Pidgey
                    Weight = 20
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 19, // Rattata
                    Weight = 15
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 21, // Spearow
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 23, // Ekans
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 25, // Pikachu
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 27, // Sandshrew
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 29, // Nidoran♀
                    Weight = 1
                },
                new CatchZone
                {
                    CityNumber = 1,
                    PokemonSpeciesId = 32, // Nidoran♂
                    Weight = 1
                },

                // =====================================================
                // CITY 2 - CERULEAN CITY
                // More type variety, still stage 1 focused.
                // =====================================================

                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 43, // Oddish
                    Weight = 16
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 46, // Paras
                    Weight = 12
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 48, // Venonat
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 52, // Meowth
                    Weight = 12
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 54, // Psyduck
                    Weight = 15
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 56, // Mankey
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 60, // Poliwag
                    Weight = 15
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 63, // Abra
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 66, // Machop
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 2,
                    PokemonSpeciesId = 69, // Bellsprout
                    Weight = 12
                },

                // =====================================================
                // CITY 3 - VERMILION CITY
                // Final city where Wild/Trainer are stage 1 only.
                // =====================================================

                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 58, // Growlithe
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 72, // Tentacool
                    Weight = 16
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 74, // Geodude
                    Weight = 12
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 77, // Ponyta
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 79, // Slowpoke
                    Weight = 12
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 81, // Magnemite
                    Weight = 12
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 84, // Doduo
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 86, // Seel
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 88, // Grimer
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 3,
                    PokemonSpeciesId = 90, // Shellder
                    Weight = 6
                },

                // =====================================================
                // CITY 4 - CELADON CITY
                //
                // Catch:
                // Stage 1
                //
                // Wild:
                // Mostly Stage 2
                //
                // Therefore both stages are present.
                // =====================================================

                // Stage 1

                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 43, // Oddish
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 46, // Paras
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 48, // Venonat
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 52, // Meowth
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 56, // Mankey
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 69, // Bellsprout
                    Weight = 8
                },

                // Stage 2

                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 11, // Metapod
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 14, // Kakuna
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 17, // Pidgeotto
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 20, // Raticate
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 22, // Fearow
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 24, // Arbok
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 28, // Sandslash
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 44, // Gloom
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 4,
                    PokemonSpeciesId = 49, // Venomoth
                    Weight = 6
                },

                // =====================================================
                // CITY 5 - FUCHSIA CITY
                //
                // Catch remains Stage 1.
                // Wild/Trainer heavily favor Stage 2.
                // =====================================================

                // Stage 1

                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 72, // Tentacool
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 77, // Ponyta
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 79, // Slowpoke
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 81, // Magnemite
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 84, // Doduo
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 86, // Seel
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 88, // Grimer
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 90, // Shellder
                    Weight = 6
                },

                // Stage 2

                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 30, // Nidorina
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 33, // Nidorino
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 42, // Golbat
                    Weight = 10
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 47, // Parasect
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 51, // Dugtrio
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 53, // Persian
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 55, // Golduck
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 57, // Primeape
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 61, // Poliwhirl
                    Weight = 8
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 64, // Kadabra
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 67, // Machoke
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 5,
                    PokemonSpeciesId = 70, // Weepinbell
                    Weight = 7
                },

                // =====================================================
                // CITY 6 - SAFFRON CITY
                //
                // Catch:
                // Stage 1 / Stage 2
                //
                // Wild/Trainer:
                // Stage 2 / Stage 3
                // =====================================================

                // Stage 1 - catch possibilities

                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 54, // Psyduck
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 58, // Growlithe
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 63, // Abra
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 66, // Machop
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 74, // Geodude
                    Weight = 5
                },

                // Stage 2

                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 26, // Raichu
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 28, // Sandslash
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 44, // Gloom
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 55, // Golduck
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 57, // Primeape
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 59, // Arcanine
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 61, // Poliwhirl
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 64, // Kadabra
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 67, // Machoke
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 73, // Tentacruel
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 75, // Graveler
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 80, // Slowbro
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 82, // Magneton
                    Weight = 5
                },

                // Stage 3

                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 12, // Butterfree
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 15, // Beedrill
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 18, // Pidgeot
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 31, // Nidoqueen
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 34, // Nidoking
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 45, // Vileplume
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 62, // Poliwrath
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 65, // Alakazam
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 68, // Machamp
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 71, // Victreebel
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 6,
                    PokemonSpeciesId = 76, // Golem
                    Weight = 3
                },

                // =====================================================
                // CITY 7 - CINNABAR ISLAND
                //
                // Strong evolved Pokémon dominate.
                // =====================================================

                // Stage 1 - catch pool

                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 58, // Growlithe
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 72, // Tentacool
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 77, // Ponyta
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 86, // Seel
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 88, // Grimer
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 90, // Shellder
                    Weight = 5
                },

                // Stage 2

                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 59, // Arcanine
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 73, // Tentacruel
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 75, // Graveler
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 78, // Rapidash
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 80, // Slowbro
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 82, // Magneton
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 85, // Dodrio
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 87, // Dewgong
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 89, // Muk
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 91, // Cloyster
                    Weight = 5
                },

                // Stage 3

                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 3, // Venusaur
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 6, // Charizard
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 9, // Blastoise
                    Weight = 3
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 31, // Nidoqueen
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 34, // Nidoking
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 45, // Vileplume
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 62, // Poliwrath
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 65, // Alakazam
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 68, // Machamp
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 71, // Victreebel
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 7,
                    PokemonSpeciesId = 76, // Golem
                    Weight = 4
                },

                // =====================================================
                // CITY 8 - VIRIDIAN CITY
                //
                // Wild/Trainer: Stage 3 only.
                // Catch can still offer Stage 1/2 according
                // to CityRegistry.
                // =====================================================

                // Stage 1 - rare catch options

                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 27, // Sandshrew
                    Weight = 2
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 29, // Nidoran♀
                    Weight = 2
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 32, // Nidoran♂
                    Weight = 2
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 63, // Abra
                    Weight = 2
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 66, // Machop
                    Weight = 2
                },

                // Stage 2 - primary catch pool

                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 28, // Sandslash
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 30, // Nidorina
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 33, // Nidorino
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 42, // Golbat
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 55, // Golduck
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 57, // Primeape
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 59, // Arcanine
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 64, // Kadabra
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 67, // Machoke
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 75, // Graveler
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 80, // Slowbro
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 82, // Magneton
                    Weight = 5
                },

                // Stage 3 - Wild/Trainer pool

                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 3, // Venusaur
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 6, // Charizard
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 9, // Blastoise
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 12, // Butterfree
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 15, // Beedrill
                    Weight = 4
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 18, // Pidgeot
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 31, // Nidoqueen
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 34, // Nidoking
                    Weight = 7
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 45, // Vileplume
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 62, // Poliwrath
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 65, // Alakazam
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 68, // Machamp
                    Weight = 6
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 71, // Victreebel
                    Weight = 5
                },
                new CatchZone
                {
                    CityNumber = 8,
                    PokemonSpeciesId = 76, // Golem
                    Weight = 6
                }
            };

            context.CatchZones.AddRange(
                catchZones
            );
        }
    }
}