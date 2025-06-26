-- itemID -> 2270

DROP VIEW IF EXISTS mainTable;
CREATE TEMPORARY VIEW IF NOT EXISTS mainTable (
  itemID, title, type, date, url, doi
) AS SELECT
  items.itemid,
  group_concat(CASE WHEN fieldname = 'title' THEN itemdatavalues.value END) AS title,
  group_concat(CASE WHEN fieldname = 'type' THEN itemdatavalues.value END) AS type,
  group_concat(CASE WHEN fieldname = 'date' THEN itemdatavalues.value END) AS date,
  group_concat(CASE WHEN fieldname = 'url' THEN itemdatavalues.value END) AS url,
  group_concat(CASE WHEN fieldname = 'DOI' THEN itemdatavalues.value END) AS doi
FROM
  items
LEFT JOIN itemdata ON items.itemid = itemdata.itemid
LEFT JOIN fieldscombined ON itemdata.fieldid = fieldscombined.fieldid
LEFT JOIN itemdatavalues ON itemdata.valueid = itemdatavalues.valueid
GROUP BY items.itemid;

SELECT
  mainTable.*,
  json_group_array(json_object('f', creators.firstName, 'l', creators.lastName, 'm', creators.fieldMode))
FROM mainTable
LEFT JOIN itemCreators ON mainTable.itemID = itemCreators.itemID
LEFT JOIN creators ON itemCreators.creatorID = creators.creatorID
GROUP BY
  mainTable.itemID;
