using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSolution.Infrastructure
{
    public static class TableNames
    {
        public const string OptionDetail = "OptionInformation";
        public const string OptionEnumGroup = "ValueEnumGroup";
        public const string OptionEnumItem = "ValueEnumItem";
        public const string OptionEnumItemGroup = "ValueEnumItemGroup";
        public const string OptionLookup = "ValueLookupObject";
        public const string OptionTreeListGrouping = "OptionTree";
    }
}

//CREATE TABLE [OptionTree] (
//[Id] INTEGER NOT NULL,

//[Category1] VARCHAR(50) NOT NULL,

//[Category2] VARCHAR(50),
//[Category3] VARCHAR(50),
//[Category4] VARCHAR(50),
//PRIMARY KEY([Id])
//    );

//CREATE TABLE[ValueEnumItem] (
//    [Id] INTEGER NOT NULL,
//[EnumItem] VARCHAR(50) NOT NULL,
//    PRIMARY KEY ([Id])
//    );

//CREATE TABLE[ValueEnumGroup] (
//    [Id] INTEGER NOT NULL,
//    PRIMARY KEY ([Id])
//    );

//CREATE TABLE[ValueEnumItemGroup] (
//    [Id] INTEGER NOT NULL,
//[GroupId] INTEGER NOT NULL,
//[ItemId] INTEGER NOT NULL,
//PRIMARY KEY ([Id]),
//CONSTRAINT[FK_ValueEnumItemGroup.GroupId]
//FOREIGN KEY([GroupId])
//REFERENCES[ValueEnumGroup]([Id]),
//CONSTRAINT[FK_ValueEnumItemGroup.ItemId]
//FOREIGN KEY([ItemId])
//REFERENCES[ValueEnumItem]([Id])
//    );

//CREATE TABLE[ValueLookupObject] (
//    [Id] INTEGER NOT NULL,
//[LookupObjectName] VARCHAR(50) NOT NULL,
//    PRIMARY KEY ([Id])
//    );

//CREATE TABLE[ValueType] (
//    [Id] INTEGER NOT NULL,
//[TypeName] VARCHAR(50) NOT NULL,
//    PRIMARY KEY ([Id])
//    );

//CREATE TABLE[OptionInformation] (
//    [Id] INTEGER NOT NULL,
//[OptionId] VARCHAR(6),
//[OptionSequence] VARCHAR(4),
//[Label] VARCHAR(155),
//[TranslationId] NUMERIC(6,0),
//[ValueTypeId] INTEGER NOT NULL,
//[ValueLookupObjectId] INTEGER,
//[ValueEnumGroupId] INTEGER,
//[OptionTreeId] INTEGER NOT NULL,
//PRIMARY KEY ([Id]),
//CONSTRAINT[FK_OptionInformation.ValueEnumGroupId]
//FOREIGN KEY([ValueEnumGroupId])
//REFERENCES[ValueEnumGroup]([Id]),
//CONSTRAINT[FK_OptionInformation.ValueTypeId]
//FOREIGN KEY([ValueTypeId])
//REFERENCES[ValueType]([Id]),
//CONSTRAINT[FK_OptionInformation.ValueLookupObjectId]
//FOREIGN KEY([ValueLookupObjectId])
//REFERENCES[ValueLookupObject]([Id]),
//CONSTRAINT[FK_OptionInformation.OptionTreeId]
//FOREIGN KEY([OptionTreeId])
//REFERENCES[OptionTree]([Id])
//    );