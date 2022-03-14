﻿using Framework.Constants;
using HermesProxy.Enums;
using HermesProxy.World;
using HermesProxy.World.Enums;
using HermesProxy.World.Objects;
using HermesProxy.World.Server.Packets;

namespace HermesProxy.World.Server
{
    public partial class WorldSocket
    {
        // Handlers for CMSG opcodes coming from the modern client
        [PacketHandler(Opcode.CMSG_PETITION_BUY)]
        void HandlePetitionBuy(PetitionBuy petition)
        {
            WorldPacket packet = new WorldPacket(Opcode.CMSG_PETITION_BUY);
            packet.WriteGuid(petition.Unit.To64());
            packet.WriteUInt32(0);
            packet.WriteUInt64(0);
            packet.WriteCString(petition.Title);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            packet.WriteUInt16(0);
            packet.WriteUInt8(0);
            packet.WriteUInt32(0);
            packet.WriteUInt32(0);
            SendPacketToServer(packet);
        }

        [PacketHandler(Opcode.CMSG_PETITION_SHOW_SIGNATURES)]
        void HandlePetitionShowSignatures(PetitionShowSignatures petition)
        {
            WorldPacket packet = new WorldPacket(Opcode.CMSG_PETITION_SHOW_SIGNATURES);
            packet.WriteGuid(petition.Item.To64());
            SendPacketToServer(packet);
        }

        [PacketHandler(Opcode.CMSG_QUERY_PETITION)]
        void HandleQueryPetition(QueryPetition petition)
        {
            WorldPacket packet = new WorldPacket(Opcode.CMSG_QUERY_PETITION);
            packet.WriteUInt32(petition.PetitionID);
            packet.WriteGuid(petition.ItemGUID.To64());
            SendPacketToServer(packet);
        }

        [PacketHandler(Opcode.CMSG_PETITION_RENAME_GUILD)]
        void HandlePetitionRenameGuild(PetitionRenameGuild petition)
        {
            WorldPacket packet = new WorldPacket(Opcode.MSG_PETITION_RENAME);
            packet.WriteGuid(petition.PetitionGuid.To64());
            packet.WriteCString(petition.NewGuildName);
            SendPacketToServer(packet);
        }

        [PacketHandler(Opcode.CMSG_OFFER_PETITION)]
        void HandleOfferPetition(OfferPetition petition)
        {
            WorldPacket packet = new WorldPacket(Opcode.CMSG_OFFER_PETITION);
            if (LegacyVersion.AddedInVersion(ClientVersionBuild.V2_0_1_6180))
                packet.WriteUInt32(petition.UnkInt);
            packet.WriteGuid(petition.ItemGUID.To64());
            packet.WriteGuid(petition.TargetPlayer.To64());
            SendPacketToServer(packet);
        }
    }
}
