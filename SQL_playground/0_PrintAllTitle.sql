SELECT
  items.itemid,
  itemdata.fieldid,
  itemdata.valueid,
  fieldscombined.fieldname,
  value
FROM
  items
LEFT JOIN itemdata ON items.itemid = itemdata.itemid
LEFT JOIN itemdatavalues ON itemdata.valueid = itemdatavalues.valueid
LEFT JOIN fieldscombined ON itemdata.fieldid = fieldscombined.fieldid
WHERE
  fieldname != 'title'
GROUP BY
  items.itemid;
