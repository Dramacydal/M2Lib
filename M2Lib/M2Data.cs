using M2Lib.Elements;
using M2Lib.Structures;
using System.IO;
using System.Linq;

namespace M2Lib
{
    [Size(0x140)]
    public class M2Data : Element
    {
        // 0
        public char[] Magic;
        // 4
        public uint Version;
        // 8
        public ArrayRef<char> Name = new ArrayRef<char>();
        // 10
        public uint GlobalModelFlags;
        // 14
        public ArrayRef<GlobalSequence> GlobalSequences = new ArrayRef<GlobalSequence>();
        // 1C
        public ArrayRef<Animation> Animations = new ArrayRef<Animation>();
        // 24
        public ArrayRef<AnimationLookup> AnimationLookups = new ArrayRef<AnimationLookup>();
        // 2C
        public ArrayRef<Bone> Bones = new ArrayRef<Bone>();
        // 34
        public ArrayRef<KeyBoneLookup> KeyBoneLookup = new ArrayRef<KeyBoneLookup>();
        // 3C
        public ArrayRef<Vertex> Vertices = new ArrayRef<Vertex>();
        // 44
        public uint nViews;
        // 48
        public ArrayRef<SubmeshAnimation> SubmeshAnimations = new ArrayRef<SubmeshAnimation>();
        // 50
        public ArrayRef<Texture> Textures = new ArrayRef<Texture>();
        // 58
        public ArrayRef<Transparency> Transparencies = new ArrayRef<Transparency>();
        // 60
        public ArrayRef<UVAnimation> UVAnimations = new ArrayRef<UVAnimation>();
        // 68
        public ArrayRef<TextureReplacement> TextureReplacements = new ArrayRef<TextureReplacement>();
        // 70
        public ArrayRef<Material> Materials = new ArrayRef<Material>();
        // 78
        public ArrayRef<BoneLookup> BoneLookups = new ArrayRef<BoneLookup>();
        // 80
        public ArrayRef<TextureLookup> TextureLookups = new ArrayRef<TextureLookup>();
        // 88
        public ArrayRef<TextureUnit> TextureUnits = new ArrayRef<TextureUnit>();  // seems removed
        // 90
        public ArrayRef<TransparencyLookup> TransparencyLookups = new ArrayRef<TransparencyLookup>();
        // 98
        public ArrayRef<AnimTextureLookup> AnimTextureLookups = new ArrayRef<AnimTextureLookup>();
        // A0
        public C3Vector[] BoundingBox = new C3Vector[2];
        // B8
        public float BoundingSphereRadius;
        // BC
        public C3Vector[] CollisionBox = new C3Vector[2];
        // D4
        public float CollisionSphereRadius;
        // D8
        public ArrayRef<BoundingTriangles> BoundingTriangles = new ArrayRef<BoundingTriangles>();
        // E0
        public ArrayRef<BoundingVertex> BoundingVertices = new ArrayRef<BoundingVertex>();
        // E8
        public ArrayRef<BoundingNormal> BoundingNormals = new ArrayRef<BoundingNormal>();
        // F0
        public ArrayRef<Attachment> Attachments = new ArrayRef<Attachment>();
        // F8
        public ArrayRef<AttachmentLookup> AttachementLookups = new ArrayRef<AttachmentLookup>();
        // 100
        public ArrayRef<Event> Events = new ArrayRef<Event>();
        // 108
        public ArrayRef<Light> Lights = new ArrayRef<Light>();
        // 110
        public ArrayRef<Camera> Cameras = new ArrayRef<Camera>();
        // 118
        public ArrayRef<CameraLookup> CameraLookups = new ArrayRef<CameraLookup>();
        // 120
        public ArrayRef<RibbonEmitter> RibbonEmitters = new ArrayRef<RibbonEmitter>();
        // 128
        public ArrayRef<ParticleEmitter> ParticleEmitters = new ArrayRef<ParticleEmitter>();
        // 130
        public ArrayRef<ushort> Unknown = new ArrayRef<ushort>();

        public bool HasExtraField()
        {
            return (GlobalModelFlags & 0x08) != 0;
        }

        public override int GetSize()
        {
            return base.GetSize() - (HasExtraField() ? 0 : 8);
        }

        public override void Read(BinaryReader stream)
        {
            Magic = stream.ReadBytes(4).Select(_ => (char)_).ToArray();
            Version = stream.ReadUInt32();
            Name.Read(stream);
            GlobalModelFlags = stream.ReadUInt32();
            GlobalSequences.Read(stream);
            Animations.Read(stream);
            AnimationLookups.Read(stream);
            Bones.Read(stream);
            KeyBoneLookup.Read(stream);
            Vertices.Read(stream);
            nViews = stream.ReadUInt32();
            SubmeshAnimations.Read(stream);
            Textures.Read(stream);
            Transparencies.Read(stream);
            UVAnimations.Read(stream);
            TextureReplacements.Read(stream);
            Materials.Read(stream);
            BoneLookups.Read(stream);
            TextureLookups.Read(stream);
            TextureUnits.Read(stream);
            TransparencyLookups.Read(stream);
            AnimTextureLookups.Read(stream);
            BoundingBox = stream.Read<C3Vector>(2);
            BoundingSphereRadius = stream.ReadSingle();
            CollisionBox = stream.Read<C3Vector>(2);
            CollisionSphereRadius = stream.ReadSingle();
            BoundingTriangles.Read(stream);
            BoundingVertices.Read(stream);
            BoundingNormals.Read(stream);
            Attachments.Read(stream);
            AttachementLookups.Read(stream);
            Events.Read(stream);
            Lights.Read(stream);
            Cameras.Read(stream);
            CameraLookups.Read(stream);
            RibbonEmitters.Read(stream);
            ParticleEmitters.Read(stream);
            if (HasExtraField())
                Unknown.Read(stream);
        }

        public override void Write(MyBinaryWriter stream)
        {
            stream.DataStartOffset += GetSize();

            stream.Write(Magic);
            stream.Write(Version);
            Name.Write(stream);
            stream.Write(GlobalModelFlags);
            GlobalSequences.Write(stream);
            Animations.Write(stream);
            AnimationLookups.Write(stream);
            Bones.Write(stream);
            KeyBoneLookup.Write(stream);
            Vertices.Write(stream);
            stream.Write(nViews);
            SubmeshAnimations.Write(stream);
            Textures.Write(stream);
            Transparencies.Write(stream);
            UVAnimations.Write(stream);
            TextureReplacements.Write(stream);
            Materials.Write(stream);
            BoneLookups.Write(stream);
            TextureLookups.Write(stream);
            TextureUnits.Write(stream);
            TransparencyLookups.Write(stream);
            AnimTextureLookups.Write(stream);
            for (var i = 0; i < BoundingBox.Length; ++i)
                stream.Write<C3Vector>(BoundingBox[i]);
            stream.Write(BoundingSphereRadius);
            for (var i = 0; i < CollisionBox.Length; ++i)
                stream.Write<C3Vector>(CollisionBox[i]);
            stream.Write(CollisionSphereRadius);
            BoundingTriangles.Write(stream);
            BoundingVertices.Write(stream);
            BoundingNormals.Write(stream);
            Attachments.Write(stream);
            AttachementLookups.Write(stream);
            Events.Write(stream);
            Lights.Write(stream);
            Cameras.Write(stream);
            CameraLookups.Write(stream);
            RibbonEmitters.Write(stream);
            ParticleEmitters.Write(stream);
            if (HasExtraField())
                Unknown.Write(stream);
        }
    }

}
