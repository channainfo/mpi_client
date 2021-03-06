﻿Namespace DataAccess.Constant
    Public Class GeneralConstants
        Public Const SP_INSERT_NEW_PATIENT As String = "dbo.sp_insert_new_patient"
        Public Const SP_GET_ALL_PATIENTS As String = "dbo.sp_get_all_patients"
        Public Const SP_GET_PATIENT_BY_ID As String = "dbo.sp_get_patient_by_id"
        Public Const SP_GET_ALL_PATIENTS_BY_GENDER As String = "dbo.sp_get_all_patients_by_gender"
        Public Const SP_GET_ALL_NONSYN_PATIENTS As String = "dbo.sp_get_all_nonsyn_patients"
        Public Const SP_GET_ALL_NONSYN_PATIENTS_AND_VISITS As String = "dbo.sp_get_all_nonsyn_patients_and_visits"
        Public Const SP_GET_ALL_NONSYN_PATIENTS_BY_GENDER As String = "dbo.sp_get_all_nonsyn_patients_by_gender"
        Public Const SP_UPDATE_PATIENT_ID As String = "dbo.sp_update_patient_id"
        Public Const SP_UPDATE_PATIENT As String = "dbo.sp_update_patient"
        Public Const SP_GET_ALL_VISITS As String = "dbo.sp_get_all_visits"
        Public Const SP_GET_ALL_NON_SYN_VISITS As String = "dbo.sp_get_all_non_syn_visits"
        Public Const SP_INSERT_NEW_VISIT As String = "dbo.sp_insert_new_visit"
        Public Const SP_INSERT_NEW_VISIT_WITH_GIVEN_ID As String = "dbo.sp_insert_new_visit_with_given_ID"
        Public Const SP_UPDATE_VISIT_ID As String = "dbo.sp_update_visit_id"
        Public Const SP_UPDATE_PATIENT_STATUS_TO_SYN As String = "dbo.sp_update_patient_status_to_syn"
        Public Const SP_DELETE_PATIENT_VISITS As String = "dbo.sp_delete_patient_visits"
        Public Const SP_UPDATE_PATIENT_AGE As String = "dbo.sp_update_patient_age"
        Public Const SP_INSERT_NEW_PATIENT_WITH_GIVEN_ID As String = "sp_insert_new_patient_with_given_ID"
    End Class
End Namespace